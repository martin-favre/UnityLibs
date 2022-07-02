namespace StateMachine
{

    class MachineTerminatedState : UpdatelessState
    {
        public override UpdatelessState HandleEvent(IStateEvent happening)
        {
            throw new System.NotImplementedException();
        }
    }

}