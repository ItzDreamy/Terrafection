using System;
using System.Collections.Generic;
using Infrastructure.Factory;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.WorldGeneration;
using Infrastructure.StateMachines.GameStateMachine.States;

namespace Infrastructure.StateMachines.GameStateMachine {
    public class GameStateMachine : StateMachine {
        public GameStateMachine(SceneLoader sceneLoader, AllServices services) {
            States = new Dictionary<Type, IExitableState> {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, services),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, services.Single<IGameFactory>()),
                [typeof(LoadProgressState)] = new LoadProgressState(this, services.Single<IPersistantProgressService>(),
                    services.Single<ISaveLoadService>()),
                [typeof(WorldGenerationState)] = new WorldGenerationState(this, services.Single<IGameFactory>(),
                    services.Single<IWorldConfigProvider>()),
                [typeof(InitializationPlayerState)] = new InitializationPlayerState(this,
                    services.Single<IGameFactory>(), services.Single<IPersistantProgressService>()),
                [typeof(GameLoopState)] = new GameLoopState(this)
            };
        }
    }
}