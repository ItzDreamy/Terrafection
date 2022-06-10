namespace Architecture.StateMachines.States {
    public interface IPayloadedState<TPayLoad> : IExitableState {
        void Enter(TPayLoad worldName);
    }
}