using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Instrumentation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using bSeamless.DotNetProg.Model.V1.Services;
using St.Eg.Ninject.Runnerr.Constraints;
using St.Eg.Ninject.Runnerr.Interceptors;
using St.Eg.Ninject.Runnerr.Modules;
using St.Eg.Ninject.Runnerr.Providers;
using St.Eg.Ninject.Runnerr.ViewModels;
using Ninject;
using Ninject.Extensions.Conventions.Syntax;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Syntax;
using Ninject.Extensions.Conventions;

namespace St.Eg.Ninject.Runnerr
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            //p.ex10_WhenInjectedInto();
            //p.ex11_WithModule();
            //p.ex12_XMLConfig();
            //p.ex13_ConventionBasedConfig();
            //p.ex14_Lazy();
            //p.ex15_ConstraintByAttribute();
            //p.ex16_RequiresConstraint();
            //p.ex17_ContextBased();
            //p.ex18_GenericProvider();
            p.ex19_Interception();

            Console.ReadLine();
        }

        public Program()
        {
            
        }

        private void ex1_BasicRegistrationAndGet()
        {
            // demonstrate registration and get
            var kernel = new StandardKernel();
            kernel.Bind<IDataService>().To<MockDataService>();
            
            var service = kernel.Get<IDataService>();

            Console.WriteLine(service.ID);
            service.GetEmployees();
            //employees.ToList().ForEach(
              //  e => Console.WriteLine("{0} {1}", e.FirstName, e.LastName));
        }

        private void ex2_ReturnsMultiInstances()
        {
            var kernel = new StandardKernel();
            // multiple resolves give
            kernel.Bind<IDataService>().To<MockDataService>();

            var service1 = kernel.Get<IDataService>();
            var service2 = kernel.Get<IDataService>();
            Console.WriteLine(service1.ID);
            Console.WriteLine(service2.ID);
        }

        private void ex3_SingletonScope()
        {
            var kernel = new StandardKernel();
            // demonstrate concrete types auto registered
            kernel.Bind<IDataService>().To<MockDataService>().InSingletonScope();

            var service1 = kernel.Get<IDataService>();
            var service2 = kernel.Get<IDataService>();
            Console.WriteLine(service1.ID);
            Console.WriteLine(service2.ID);
        }

        private void ex4_RegisterByName()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IDataService>().To<MockDataService>().Named("Mock");
            kernel.Bind<IDataService>().To<EFDataService>().Named("EF");

            var service1 = kernel.Get<IDataService>("Mock");
            var service2 = kernel.Get<IDataService>("EF");

            Console.WriteLine(service1.GetType().Name);
            Console.WriteLine(service2.GetType().Name);
        }

        private void ex5_WithMethod()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IDataService>().ToMethod(c =>
            {
                Console.WriteLine("Creating data service");
                var service = new MockDataService();
                return service;
            });
            kernel.Get<IDataService>();
        }

        private void ex6_WithActivation()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IDataService>().To<MockDataService>().InSingletonScope()
                .OnActivation(s =>
                {
                    Console.WriteLine("Activating: {0} {1}",
                        s.GetType().Name,
                        s.ID);
                });

            kernel.Get<IDataService>();
            kernel.Get<IDataService>();
            kernel.Get<IDataService>();
        }

        private void ex7_ThreadScope()
        {
            var kernel = new StandardKernel();
            var report = new Action<string, IDataService>((m, s) =>
            {
                Console.WriteLine("{0} {1}", m, s.ID);
            });


            kernel.Bind<IDataService>().To<MockDataService>()//.InThreadScope()
                .OnActivation(s => report("Activating", s))
                .OnDeactivation(s => report("Deactivating", s));

            var t = Task.Factory.StartNew(
                () =>
                {
                    Console.WriteLine("Starting task");
                    try
                    {
                        Task.Delay(1000).Wait();

                        Console.WriteLine("task creating instances");

                        report("Task1", kernel.Get<IDataService>());
                        report("Task2", kernel.Get<IDataService>());

                        Task.Delay(2000).Wait();
                        Console.WriteLine("task complete");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                });
            t.ContinueWith(p =>
            {
                Console.WriteLine("Task continuation");
                GC.Collect(GC.MaxGeneration);

            });

            report("Main1", kernel.Get<IDataService>());
            report("Main2", kernel.Get<IDataService>());
            Task.Delay(5000).Wait();
            Console.WriteLine("Complete");
        }

        private void ex8_ConstructorInjection()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IDataService>().To<MockDataService>();
            kernel.Get<MockConstructorInjectionViewModel>();
        }

        private void ex9_PropertyInjection()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IDataService>().To<MockDataService>();
            kernel.Get<MockPropertyInjectionViewModel>();
        }

        private void ex10_WhenInjectedInto()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IDataService>().To<MockDataService>()
                .WhenInjectedInto<MockConstructorInjectionViewModel>();
            kernel.Bind<IDataService>().To<EFDataService>()
                .WhenInjectedInto<MockPropertyInjectionViewModel>();

            kernel.Get<MockConstructorInjectionViewModel>();
            kernel.Get<MockPropertyInjectionViewModel>();
        }

        private void ex11_WithModule()
        {
            var kernel = new StandardKernel(new MockRegistrationModule());
            //kernel = new StandardKernel(new EFRegistrationModule());
            kernel.Get<IDataService>();
        }

        private void ex12_XMLConfig()
        {
            var kernel = new StandardKernel();
            kernel.Load("Config/*.xml");
            Console.WriteLine("Loaded");
            kernel.Get<IDataService>();
        }

        private void ex13_ConventionBasedConfig()
        {
            // requires Ninject.Extensions.Conventions
            var kernel = new StandardKernel();
            kernel.Bind(x =>
                x.FromAssemblyContaining<DataServiceBase>()
                    .SelectAllClasses()
                    .InheritedFrom<IDataService>()
                    .BindSingleInterface()
                    .Configure(b => b.InSingletonScope()));

            kernel.Get<IDataService>();
        }

        private void ex14_Lazy()
        {
            // thi may not be working correctly
            var kernel = new StandardKernel();
            kernel.Bind<IDataService>().To<MockDataService>();
            var vm = kernel.Get<LazyMockPropertyInjectionViewModel>();
            Console.WriteLine("Got vm");
            vm.execute();
        }

        private void ex15_ConstraintByAttribute()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IDataService>().To<MockDataService>().WithMetadata("IsMock", true);
            kernel.Bind<IDataService>().To<NServiceBusDataService>().WithMetadata("IsMessaging", true);
            kernel.Bind<IDataService>().To<EFDataService>().WithMetadata("IsEF", true);

            var vm = kernel.Get<MetadataConstrainedConstructorInjectionViewModel>();
        }

        private void ex16_RequiresConstraint()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IDataService>().To<NServiceBusDataService>()
                .WhenClassHas<MessagingRequired>();

            var vm = kernel.Get<MessagingRequiredConstructorInjectionViewModel>();
        }

        private void ex17_ContextBased()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IDataService>().To<EFDataService>()
                .When(request => request.Target.Name.StartsWith("ef"));
            var vm = kernel.Get<RequiresEFViewModel>();
        }

        private void ex18_GenericProvider()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IDataService>().ToProvider(new DataServiceProvider());
            var vm = kernel.Get<IDataService>();
        }

        private void ex19_Interception()
        {
            var kernel = new StandardKernel();
            //kernel.Bind<IDataService>().To<MockDataService>();//.Intercept().With<LoggingInterceptor>();
            //kernel.Bind<MockDataService>().ToSelf().Intercept().With(new LoggingInterceptor());
            /*
            kernel.InterceptAround<MockDataService>(
                c => c.GetEmployees2(),
                invocation =>
                {
                    Console.WriteLine("Before GetEmployees()");
                },
                invocation =>
                {
                    Console.WriteLine("After GetEmployees()");
                    Console.WriteLine(invocation.ReturnValue);
                });
             */
            //kernel.InterceptReplace<MockDataService>(
              //  c => c.GetEmployees2(),
                //invocation => { Console.WriteLine("HI"); });
            /*
            kernel.InterceptAround<Foo>(
                f => f.bar(),
                i =>
                {
                    Console.WriteLine("Before {0} {1} {2}", i.Request.Method.Name, i.Request.Target, i.Request.Arguments);
                },
                i =>
                {
                    Console.WriteLine("After"); 
                });
            */
            /*
            kernel.Bind<MockDataService>().ToSelf();
            kernel.InterceptAround<MockDataService>(f => f.GetEmployees(),
                i => { Console.WriteLine("befor bar()"); },
                i => { Console.WriteLine("after bar()"); });
            
            var s = kernel.Get<MockDataService>();
            //Console.WriteLine(s.GetType().Name);
            s.GetEmployees();
            //Console.WriteLine(employees);
             * */
        }
    }
}
