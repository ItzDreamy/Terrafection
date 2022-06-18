using Infrastructure.Factory;

namespace Infrastructure.StateMachines.States {
    public class LoadLevelState : IPayloadedState<string> {
        private readonly IGameFactory _gameFactory;
        private readonly SceneLoader _sceneLoader;
        private readonly GameStateMachine _stateMachine;
        private string _worldName;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, IGameFactory gameFactory) {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
        }

        public void Enter(string worldName) {
            _gameFactory.Cleanup();
            _worldName = worldName;
            _sceneLoader.Load("Main", OnLoaded);
        }

        public void Exit() {
        }

        private void OnLoaded() {
            _stateMachine.Enter<LoadProgressState, string>(_worldName);
        }
    }
}