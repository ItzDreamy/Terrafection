namespace Infrastructure.StateMachines.States {
    public interface IState : IExitableState {
        void Enter();
    }
}