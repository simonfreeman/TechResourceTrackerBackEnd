using System.Timers;

namespace TechResourceService
{
    interface ITechResourceTracker
    {
        int TimerInterval { get; set; }

        void InitiateTimer();
        void OnTimer(object sender, ElapsedEventArgs args);
        void TimerActivities();
    }
}