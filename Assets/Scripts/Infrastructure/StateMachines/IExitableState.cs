namespace Infrastructure.StateMachines {
    public interface IExitableState {
        void Exit();
        void LogicUpdate();
        void PhysicsUpdate();
    }
}