namespace StateMachine
{

    class NoTransitionState : UpdatelessState
    {
        public override UpdatelessState HandleEvent(IStateEvent happening)
        {
            throw new System.NotImplementedException();
        }
    }

}