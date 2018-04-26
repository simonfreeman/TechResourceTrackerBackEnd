using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TechResourceService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
#if (DEBUG)
            //Debugging a service is unideal but it's better than installing and uninstalling a service every time
            TechResourceTracker myServ = new TechResourceTracker
            {
                TimerInterval = 10000 //waiting for release timer periods is a tad tedious
            };
            myServ.InitiateTimer();

            //Force the program to run for 30 seconds so the timer can actually loop a few times.
            Task.Run(async () =>
            {
                await Task.Delay(30000);// 
            }).GetAwaiter().GetResult();
#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new tech_resource_tracker_service()
            };
            ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
