namespace StateMachine
{

    public abstract class UpdatelessState
    {

        public UpdatelessState() { }
        public virtual void OnEntry() { }
        public virtual void OnExit() { }

        public abstract UpdatelessState HandleEvent(IStateEvent happening);

    }

}