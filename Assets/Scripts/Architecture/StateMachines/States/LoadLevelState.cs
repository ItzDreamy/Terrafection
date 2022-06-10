using Architecture.Factory;
using Architecture.Services.PersistentProgress;

namespace Architecture.StateMachines.States {
    public class LoadLevelState : IState {
        private readonly IGameFactory _gameFactory;
        private readonly SceneLoader _sceneLoader;
        private readonly GameStateMachine _stateMachine;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, IGameFactory gameFactory) {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
        }

        public void Enter() {
            _gameFactory.Cleanup();
            _sceneLoader.Load("Main", OnLoaded);
        }

        public void Exit() {
        }

        private void OnLoaded() {
            _stateMachine.Enter<WorldGenerationState>();
        }
    }
}