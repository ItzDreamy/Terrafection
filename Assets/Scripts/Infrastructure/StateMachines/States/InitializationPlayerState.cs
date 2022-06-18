using CameraLogic;
using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace Infrastructure.StateMachines.States {
    public class InitializationPlayerState : IPayloadedState<Vector2> {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistantProgressService _progressService;

        public InitializationPlayerState(GameStateMachine gameStateMachine, IGameFactory gameFactory,
            IPersistantProgressService progressService) {
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
            _progressService = progressService;
        }

        public void Enter(Vector2 spawnPosition) {
            InitGameWorld(spawnPosition);
            InformProgressReaders();
            _gameStateMachine.Enter<GameLoopState>();
        }

        public void Exit() {
        }

        private void InformProgressReaders() {
            foreach (ISavedProgressReader reader in _gameFactory.ProgressReaders) {
                reader.LoadProgress(_progressService.Progress);
            }
        }

        private void InitGameWorld(Vector2 spawnPosition) {
            if (_gameFactory.WorldParent == null) _gameFactory.CreateWorldParent();
            GameObject hero = SpawnPlayer(spawnPosition);
            CameraFollow(hero);
            InitHud(hero);
        }

        private void InitHud(GameObject hero) {
            _gameFactory.CreateHud();
        }

        private GameObject SpawnPlayer(Vector2 spawnPosition) =>
            _gameFactory.CreateHero(spawnPosition);

        private void CameraFollow(GameObject hero) =>
            Camera.main.GetComponent<CameraFollow>().Follow(hero);
    }
}