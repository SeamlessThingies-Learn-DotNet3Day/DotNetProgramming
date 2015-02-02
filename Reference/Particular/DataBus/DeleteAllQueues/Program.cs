using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DeleteAllQueues
{
    class Program
    {
        static void Main(string[] args)
        {
            DeleteAppQueues();
            
        }

        public static void DeleteAppQueues()
        {
            List<string> trash = new List<string>();

            var machineQueues = MessageQueue.GetPrivateQueuesByMachine(".");
            foreach (var q in machineQueues)
            {
//#if (IsAppQueue(q.QueueName))
                {
                    trash.Add(".\\" + q.QueueName);
                } 
                q.Dispose();
            }

            foreach (var queueName in trash)
            {
                try
                {
                    using (MessageQueue delQueue = new MessageQueue(queueName))
                    {
                        delQueue.SetPermissions("Everyone", MessageQueueAccessRights.FullControl, AccessControlEntryType.Allow);
                    }
                    MessageQueue.Delete(queueName);
                }
                catch (MessageQueueException ex)
                {
                    // ex.Message is "Access to Message Queuing system is denied."
                }
            }
        }
    }

}
