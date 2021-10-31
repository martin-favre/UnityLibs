namespace StateMachine
{

    public abstract class State
    {

        private bool machineTerminated = false;

        public bool MachineTerminated { get => machineTerminated; }

        public State() { }
        public virtual void OnEntry() { }
        public abstract State OnDuring();
        public virtual void OnExit() { }

        public virtual EventResult HandleEvent(IStateEvent happening)
        {
            return EventResult.EventNotHandled;
        }
        protected void TerminateMachine()
        {
            machineTerminated = true;
        }

    }

}