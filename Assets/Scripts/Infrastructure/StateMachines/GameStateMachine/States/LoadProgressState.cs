using Data.Player;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace Infrastructure.StateMachines.GameStateMachine.States {
    public class LoadProgressState : IPayloadedState<string> {
        private readonly GameStateMachine _stateMachine;
        private readonly IPersistantProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;

        public LoadProgressState(GameStateMachine stateMachine, IPersistantProgressService progressService,
            ISaveLoadService saveLoadService) {
            _stateMachine = stateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }

        public void Exit() {
        }

        public void Enter(string worldName) {
            LoadProgressOrInitNew(worldName);

            if (_progressService.Progress.WorldData.Chunks == null) {
                _stateMachine.Enter<WorldGenerationState>();
                return;
            }
            _stateMachine.Enter<InitializationPlayerState, Vector2>(Vector2.zero);
        }

        private void LoadProgressOrInitNew(string worldName) {
            _progressService.Progress = _saveLoadService.LoadProgress(worldName) ?? NewProgress(worldName);
        }

        private PlayerProgress NewProgress(string worldName) {
            return new PlayerProgress(worldName);
        }
    }
}