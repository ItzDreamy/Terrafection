using Data.Player;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;

namespace Infrastructure.StateMachines.States {
    public class LoadProgressState : IState {
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

        public void Enter() {
            LoadProgressOrInitNew();
            _stateMachine.Enter<WorldGenerationState>();
        }

        private void LoadProgressOrInitNew() {
            _progressService.Progress = _saveLoadService.LoadProgress("Main") ?? NewProgress();
        }

        private PlayerProgress NewProgress() {
            return new PlayerProgress("Main");
        }
    }
}