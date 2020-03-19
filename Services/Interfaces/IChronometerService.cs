namespace Services.Interfaces
{
    public interface IChronometerService
    {
        string Value { get; }

        void AddSecond();

        void Start();

        void Pause();

        void Stop();

        void SetCurrentSecond(int seconds);
    }
}
