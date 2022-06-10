using Architecture.Scripts.AssetManagement;
using Architecture.Scripts.Factory;
using Architecture.Scripts.Services;
using Architecture.Scripts.Services.Input;
using UnityEngine.Device;

namespace Architecture.Scripts.StateMachines.States {
    public class BootstrapState : IState {
        private const string Boot = "Boot";
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;
        private readonly GameStateMachine _stateMachine;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services) {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;

            RegisterServices();
        }

        public void Enter() {
            _sceneLoader.Load(Boot, EnterLoadLevel);
        }

        public void Exit() {
        }

        private void EnterLoadLevel() {
            _stateMachine.Enter<LoadLevelState, string>("Main");
        }

        private void RegisterServices() {
            _services.RegisterSingle(InputService());
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IGameFactory>(
                new GameFactory(_services.Single<IAssetProvider>()));
        }

        private static IInputService InputService() {
            return Application.isMobilePlatform ? new MobileInputService() : new StandaloneInputService();
        }
    }
}