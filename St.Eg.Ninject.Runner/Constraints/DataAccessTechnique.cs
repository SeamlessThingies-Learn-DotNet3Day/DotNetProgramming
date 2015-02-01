using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Planning.Bindings;

namespace bSeamless.DotNetProg.Model.V1.Services.Constraints
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field |
        AttributeTargets.Parameter | AttributeTargets.Class, 
        AllowMultiple=true, Inherited=true)]
    public class DataAccessTechnique : ConstraintAttribute
    {
        protected string _name;
        protected bool _value = true;

        public override bool Matches(IBindingMetadata metadata)
        {
            return metadata.Has(_name) && metadata.Get<bool>(_name);
        }
    }

//    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field |
 //   AttributeTargets.Parameter, AllowMultiple = true, Inherited = true)]
    public class MockAccessTechnique : DataAccessTechnique
    {
        public MockAccessTechnique()
        {
            _name = "IsMock";
        }
    }
    public class EFAccessTechnique : DataAccessTechnique
    {
        public EFAccessTechnique()
        {
            _name = "IsEF";
        }
    }

    public class MessagingAccessTechnique : DataAccessTechnique
    {
        public MessagingAccessTechnique()
        {
            _name = "IsMessaging";
        }
    }

}
