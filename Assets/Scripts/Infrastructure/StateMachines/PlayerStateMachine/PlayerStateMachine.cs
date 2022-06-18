using System;
using System.Collections.Generic;
using Infrastructure.Services;

namespace Infrastructure.StateMachines.PlayerStateMachine {
    public class PlayerStateMachine : StateMachine {
        public PlayerStateMachine(AllServices services) {
            States = new Dictionary<Type, IExitableState>() {
                
            };
        }
    }
}