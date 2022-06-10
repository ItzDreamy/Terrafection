using Architecture.Factory;
using Architecture.Services.PersistentProgress;
using UnityEngine;

namespace Architecture.StateMachines.States {
    public class LoadLevelState : IState {
        private readonly IGameFactory _gameFactory;
        private readonly IPersistantProgressService _persistantProgressService;
        private readonly SceneLoader _sceneLoader;
        private readonly GameStateMachine _stateMachine;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, IGameFactory gameFactory,
            IPersistantProgressService persistantProgressService) {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _persistantProgressService = persistantProgressService;
        }

        public void Enter() {
            _gameFactory.Cleanup();
            _sceneLoader.Load("Main", OnLoaded);
        }

        public void Exit() {
        }

        private void OnLoaded() {
            InitGameWorld();
            InformProgressReaders();

            _stateMachine.Enter<GameLoopState>();
        }

        private void InformProgressReaders() {
            foreach (ISavedProgressReader reader in _gameFactory.ProgressReaders) {
                reader.LoadProgress(_persistantProgressService.Progress);
            }
        }

        private void InitGameWorld() {
            var hero = _gameFactory.CreateHero(Vector2.zero);
            _gameFactory.CreateHud();
        }
    }
}