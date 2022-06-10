using Architecture.Factory;
using Architecture.Services.PersistentProgress;
using UnityEngine;

namespace Architecture.StateMachines.States {
    public class InitializationPlayerState : IState {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistantProgressService _progressService;

        public InitializationPlayerState(GameStateMachine gameStateMachine, IGameFactory gameFactory,
            IPersistantProgressService progressService) {
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
            _progressService = progressService;
        }

        public void Exit() {
        }

        public void Enter() {
            InitGameWorld();
            InformProgressReaders();
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void InformProgressReaders() {
            foreach (ISavedProgressReader reader in _gameFactory.ProgressReaders) {
                reader.LoadProgress(_progressService.Progress);
            }
        }

        private void InitGameWorld() {
            var hero = _gameFactory.CreateHero(Vector2.zero);
            _gameFactory.CreateHud();
        }
    }
}