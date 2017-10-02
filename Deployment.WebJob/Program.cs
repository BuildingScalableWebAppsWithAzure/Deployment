using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.ServiceBus; 

namespace Deployment.WebJob
{
    class Program
    {
        static void Main()
        {
            var config = new JobHostConfiguration();
            ServiceBusConfiguration serviceBusConfig = new ServiceBusConfiguration();
            serviceBusConfig.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["ServiceBusConnectionString"];
            config.UseServiceBus(serviceBusConfig); 
            var host = new JobHost(config);
            // The following code ensures that the WebJob will be running continuously
            host.RunAndBlock();
        }
    }
}
