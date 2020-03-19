using System;
using System.Windows.Threading;
using Services.Interfaces;

namespace Services.Implementation
{
    public class ChronometerService : IChronometerService
    {
        private static DispatcherTimer timer;

        public ChronometerService()
        {
            SetCurrentSecond();
        }

        private int CurrentSeconds { get; set; }

        public string Value
        {
            get
            {
                int NewCurrentSeconds = SubtractDayPassed(CurrentSeconds);
                CurrentSeconds = NewCurrentSeconds;
                return TimeSpan.FromSeconds(CurrentSeconds).ToString();
            }
        }

        #region Public Methods

        public static ChronometerService Create(EventHandler eventHandler)
        {
            const int Interval = 1;

            ChronometerService ChronoService = new ChronometerService();

            // Create a timer with a 1 second interval.
            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(Interval)
            };

            // Hook up the event handler for the Elapsed event.
            timer.Tick += eventHandler;

            return ChronoService;
        }

        public void AddSecond()
        {
            CurrentSeconds++;
        }

        public void Start()
        {
            timer.Start();
        }

        public void Pause()
        {
            timer.Stop();
        }

        public void Stop()
        {
            timer.Stop();
            SetCurrentSecond();
        }

        public void SetCurrentSecond(int seconds)
        {
            CurrentSeconds = seconds;
        }

        #endregion

        #region Private Methods
        private void SetCurrentSecond()
        {
            SetCurrentSecond(0);
        }

        // When total seconds surpasses 1 day, start counting from 0.
        private int SubtractDayPassed(int seconds)
        {
            const int SecondsInDay = 86400;   // 60sec * 60min * 24hrs
            return seconds >= SecondsInDay ? seconds - SecondsInDay : seconds;
        }

        #endregion
    }
}
