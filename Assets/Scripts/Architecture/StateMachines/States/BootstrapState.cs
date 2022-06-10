using Architecture.AssetManagement;
using Architecture.Factory;
using Architecture.Services;
using Architecture.Services.Input;
using Architecture.Services.PersistentProgress;
using Architecture.Services.SaveLoad;
using UnityEngine.Device;

namespace Architecture.StateMachines.States {
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
            _stateMachine.Enter<LoadLevelState>();
        }

        private void RegisterServices() {
            _services.RegisterSingle(InputService());
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IPersistantProgressService>(new PersistantProgressService());
            _services.RegisterSingle<IGameFactory>(
                new GameFactory(_services.Single<IAssetProvider>()));
            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(_services.Single<IGameFactory>(),
                _services.Single<IPersistantProgressService>()));
        }

        private static IInputService InputService() {
            return Application.isMobilePlatform ? new MobileInputService() : new StandaloneInputService();
        }
    }
}