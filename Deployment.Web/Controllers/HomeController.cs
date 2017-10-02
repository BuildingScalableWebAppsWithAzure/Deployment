using System.Web.Mvc;
using Deployment.Web.Models;
using System.Configuration;
using Microsoft.ServiceBus.Messaging;
using Deployment.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Deployment.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new MessageModel());
        }

        /// <summary>
        /// Takes a message submitted from our main form and enqueues it in a Service Bus Queue. 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(MessageModel model)
        {
            //enqueue our message. 
            string serviceBusConnectionString = System.Configuration.ConfigurationManager.AppSettings["ServiceBusConnectionString"];
            string queueName = ConfigurationManager.AppSettings["ServiceBusQueueName"];
            var client = QueueClient.CreateFromConnectionString(serviceBusConnectionString, queueName);
            BrokeredMessage msg = new BrokeredMessage(model.Message);
            client.Send(msg);
            return View(model); 
        }

        /// <summary>
        /// Shows a list of all messages that have been written to the database. 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Messages()
        {
            using (var deploymentCtx = new DeploymentContext())
            {
                List<ReceivedMessage> allMessages = deploymentCtx.ReceivedMessages.ToList();
                return View(allMessages);
            }
        }
    }
}