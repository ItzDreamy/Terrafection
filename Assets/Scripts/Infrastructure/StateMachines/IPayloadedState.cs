namespace Infrastructure.StateMachines {
    public interface IPayloadedState<TPayLoad> : IExitableState {
        void Enter(TPayLoad payload);
    }
}