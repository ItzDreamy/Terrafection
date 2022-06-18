using Infrastructure.Factory;
using Infrastructure.Services;
using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.Input;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.WorldGeneration;
using UnityEngine.Device;

namespace Infrastructure.StateMachines.GameStateMachine.States {
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
            RegisterBlocksData();
            RegisterGenerationConfig();
            _services.RegisterSingle(InputService());
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IPersistantProgressService>(new PersistantProgressService());
            _services.RegisterSingle<IGameFactory>(
                new GameFactory(_services.Single<IAssetProvider>(), _services.Single<IBlocksDataProvider>()));
            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(_services.Single<IGameFactory>(),
                _services.Single<IPersistantProgressService>()));
        }

        private void RegisterGenerationConfig() {
            IWorldConfigProvider worldConfigProvider = new WorldConfigProvider();
            worldConfigProvider.LoadConfig();
            _services.RegisterSingle<IWorldConfigProvider>(worldConfigProvider);
        }
        
        private void RegisterBlocksData() {
            IBlocksDataProvider blocksData = new BlocksDataProvider();
            blocksData.LoadBlocks();
            _services.RegisterSingle<IBlocksDataProvider>(blocksData);
        }
        
        private static IInputService InputService() {
            return Application.isMobilePlatform ? new MobileInputService() : new StandaloneInputService();
        }
    }
}