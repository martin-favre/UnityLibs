namespace SimpleValueDisplayer
{
    public class ValueHook : IDisposable
    {
        string lastValue = "";

        public string LastValue { get => lastValue; }

        public void UpdateValue(string value)
        {
            lastValue = value;
        }

        public void Dispose()
        {
            SimpleValueDisplayer.Instance.UnregisterValue(this);
        }

        ~ValueHook()
        {
            SimpleValueDisplayer.Instance.UnregisterValue(this);
        }

    }

}