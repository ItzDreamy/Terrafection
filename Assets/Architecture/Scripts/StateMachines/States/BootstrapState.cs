using Architecture.Scripts.Bootstrappers;
using Architecture.Scripts.Services.Input;
using UnityEngine.Device;

namespace Architecture.Scripts.StateMachines.States {
    public class BootstrapState : IState {
        private const string Boot = "Boot";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader) {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter() {
            RegisterServices();
            _sceneLoader.Load(Boot, onLoaded: EnterLoadLevel);
        }

        private void EnterLoadLevel() => _stateMachine.Enter<LoadLevelState, string>("Main");

        public void Exit() {
        }

        private void RegisterServices() => Game.InputService = RegisterInputService();

        private static IInputService RegisterInputService() =>
            Application.isMobilePlatform ? new MobileInputService() : new StandaloneInputService();
    }
}