using System;
using System.Collections.Generic;
using Architecture.Factory;
using Architecture.Services;
using Architecture.Services.PersistentProgress;
using Architecture.Services.SaveLoad;
using Architecture.Services.WorldGeneration;
using Architecture.StateMachines.States;

namespace Architecture.StateMachines {
    public class GameStateMachine {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, AllServices services) {
            _states = new Dictionary<Type, IExitableState> {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, services),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, services.Single<IGameFactory>()),
                [typeof(LoadProgressState)] = new LoadProgressState(this, services.Single<IPersistantProgressService>(),
                    services.Single<ISaveLoadService>()),
                [typeof(WorldGenerationState)] = new WorldGenerationState(this, services.Single<IGameFactory>(),
                    services.Single<IWorldConfigProvider>(), services.Single<IPersistantProgressService>()),
                [typeof(InitializationPlayerState)] = new InitializationPlayerState(this,
                    services.Single<IGameFactory>(), services.Single<IPersistantProgressService>()),
                [typeof(GameLoopState)] = new GameLoopState(this)
            };
        }

        public void Enter<TState>() where TState : class, IState {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload> {
            var state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState GetState<TState>() where TState : class, IExitableState {
            return _states[typeof(TState)] as TState;
        }

        private TState ChangeState<TState>() where TState : class, IExitableState {
            _activeState?.Exit();
            var state = GetState<TState>();
            _activeState = state;
            return state;
        }
    }
}