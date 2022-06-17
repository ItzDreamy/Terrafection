namespace Infrastructure.StateMachines.States {
    public interface IPayloadedState<TPayLoad> : IExitableState {
        void Enter(TPayLoad payload);
    }
}