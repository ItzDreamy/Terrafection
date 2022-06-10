using Architecture.Scripts.Factory;
using UnityEngine;

namespace Architecture.Scripts.StateMachines.States {
    public class LoadLevelState : IPayloadedState<string> {
        private readonly IGameFactory _gameFactory;
        private readonly SceneLoader _sceneLoader;
        private readonly GameStateMachine _stateMachine;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, IGameFactory gameFactory) {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
        }

        public void Enter(string sceneName) {
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() {
        }

        private void OnLoaded() {
            var hero = _gameFactory.CreateHero(Vector2.zero);
            _gameFactory.CreateHud();

            _stateMachine.Enter<GameLoopState>();
        }
    }
}