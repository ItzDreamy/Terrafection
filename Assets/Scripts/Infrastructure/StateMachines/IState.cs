namespace Infrastructure.StateMachines {
    public interface IState : IExitableState {
        void Enter();
    }
}