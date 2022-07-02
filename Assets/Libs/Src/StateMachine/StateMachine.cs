namespace StateMachine
{
    public class StateMachine
    {
        private UpdatelessState activeState;

        public bool IsActive { get => activeState != null; }

        public StateMachine(UpdatelessState initialState)
        {
            TransitToState(initialState);
        }

        public void RaiseEvent(IStateEvent ev)
        {
            if (activeState != null)
            {
                var nextState = activeState.HandleEvent(ev);
                if (!(nextState is NoTransitionState))
                {
                    TransitToState(nextState);
                }
            }
        }

        public static UpdatelessState NoTransition()
        {
            return new NoTransitionState();
        }


        public static UpdatelessState MachineTerminated()
        {
            return new MachineTerminatedState();
        }

        private void TransitToState(UpdatelessState nextState)
        {
            if(activeState != null)
            {
                activeState.OnExit();
            }
            if(nextState is MachineTerminatedState)
            {
                activeState = null;
            } else
            {
                activeState = nextState;
                activeState.OnEntry();
            }
        }

    }

}