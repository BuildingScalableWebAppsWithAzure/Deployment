using Microsoft.Azure.WebJobs;
using System.IO;
using System;
using Deployment.Persistence; 

namespace Deployment.WebJob
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Service Bus Message Queue called "messages"
        public static void ProcessQueueMessage([ServiceBusTrigger("messages")] string message, TextWriter log)
        {
            Console.WriteLine(message);
            ReceivedMessage msgModel = new ReceivedMessage();
            msgModel.Message = message;
            using (var deploymentCtx = new DeploymentContext())
            {
                deploymentCtx.ReceivedMessages.Add(msgModel);
                deploymentCtx.SaveChanges(); 
            }
        }
    }
}
