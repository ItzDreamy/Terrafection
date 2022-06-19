using System;
using System.Collections.Generic;

namespace Infrastructure.StateMachines {
    public class StateMachine {
        protected Dictionary<Type, IExitableState> States;
        protected IExitableState ActiveState;

        public void Enter<TState>() where TState : class, IState {
            if (ActiveState is not TState) {
                IState state = ChangeState<TState>();
                state.Enter();
            }
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload> {
            if (ActiveState is not TState) {
                var state = ChangeState<TState>();
                state.Enter(payload);
            }
        }

        private TState GetState<TState>() where TState : class, IExitableState {
            return States[typeof(TState)] as TState;
        }

        private TState ChangeState<TState>() where TState : class, IExitableState {
            ActiveState?.Exit();
            var state = GetState<TState>();
            ActiveState = state;
            return state;
        }
    }
}