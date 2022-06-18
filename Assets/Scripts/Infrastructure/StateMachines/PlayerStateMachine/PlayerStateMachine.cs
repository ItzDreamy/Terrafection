using System;
using System.Collections.Generic;
using Infrastructure.StateMachines.PlayerStateMachine.States;
using UnityEngine;

namespace Infrastructure.StateMachines.PlayerStateMachine {
    public class PlayerStateMachine : StateMachine {
        public PlayerStateMachine(Animator animator) {
            States = new Dictionary<Type, IExitableState>() {
                {typeof(IdleState), new IdleState(this, animator)},
                {typeof(MoveState), new MoveState(this, animator)},
                {typeof(DeathState), new DeathState(this, animator)}
            };
        }
    }
}