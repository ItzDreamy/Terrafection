namespace Architecture.StateMachines.States {
    public interface IState : IExitableState {
        void Enter();
    }
}