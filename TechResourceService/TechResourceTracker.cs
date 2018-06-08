using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace TechResourceService
{
    partial class TechResourceTracker : ServiceBase, ITechResourceTracker
    {
        private int eventId = 1;
        private IRssReader _reader;
        //private RssFeedReader rssFeedReader = new RssFeedReader();
        public int TimerInterval { get; set; } = 6000;

        public TechResourceTracker(IRssReader reader)
        {
            CreateEventLog();
        }

        private List<string> PodcastList
        {
            get
            {
                var podcastUrls = new List<string>
                {
                    "http://www.pwop.com/feed.aspx?show=dotnetrocks&filetype=master"
                };

                return podcastUrls;
            }
        }

        private void CreateEventLog()
        {
            eventLog1 = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "MySource", "MyTechResourcesLog");
            }
            eventLog1.Source = "MySource";
            eventLog1.Log = "MyTechResourcesLog";
        }

        protected override void OnStart(string[] args)
        {
            InitiateTimer();
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("Stopping tech resource tracking");
        }

        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            TimerActivities();
        }

        //this is dumb but debugging/testing a windows service is awkward.
        public void InitiateTimer()
        {
            eventLog1.WriteEntry("Start tracking of tech resources");
            var timer = new System.Timers.Timer
            {
                Interval = TimerInterval // 60 seconds  
            };
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        public void TimerActivities()
        {
            eventLog1.WriteEntry("Tracking resources", EventLogEntryType.Information, eventId++);


        }
    }
}
