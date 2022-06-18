using System;
using System.Collections.Generic;

namespace Infrastructure.StateMachines {
    public class StateMachine {
        protected Dictionary<Type, IExitableState> States;
        private IExitableState _activeState;

        public void Enter<TState>() where TState : class, IState {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload> {
            var state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState GetState<TState>() where TState : class, IExitableState {
            return States[typeof(TState)] as TState;
        }

        private TState ChangeState<TState>() where TState : class, IExitableState {
            _activeState?.Exit();
            var state = GetState<TState>();
            _activeState = state;
            return state;
        }
    }
}