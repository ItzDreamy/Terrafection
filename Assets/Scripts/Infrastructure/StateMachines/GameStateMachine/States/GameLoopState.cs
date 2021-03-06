namespace Infrastructure.StateMachines.GameStateMachine.States {
    public class GameLoopState : IState {
        private readonly GameStateMachine _stateMachine;

        public GameLoopState(GameStateMachine stateMachine) {
            _stateMachine = stateMachine;
        }

        public void Exit() {
        }

        public void LogicUpdate() {
        }

        public void PhysicsUpdate() {
            
        }

        public void Enter() {
        }
    }
}