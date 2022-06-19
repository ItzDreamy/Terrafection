using System;
using System.Collections.Generic;
using Hero;
using Infrastructure.Services;
using Infrastructure.Services.Input;
using Infrastructure.StateMachines.PlayerStateMachine.States;
using UnityEngine;

namespace Infrastructure.StateMachines.PlayerStateMachine {
    public class PlayerStateMachine : StateMachine {
        public PlayerStateMachine(HeroAnimator animator, Rigidbody2D rigidbody2D, Transform groundChecker,
            LayerMask layerMask) {
            States = new Dictionary<Type, IExitableState>() {
                {
                    typeof(IdleState),
                    new IdleState(this, animator, AllServices.Container.Single<IInputService>(), groundChecker,
                        layerMask, rigidbody2D)
                }, {
                    typeof(MoveState),
                    new MoveState(this, animator, AllServices.Container.Single<IInputService>(), rigidbody2D,
                        groundChecker, layerMask)
                },
                {typeof(DeathState), new DeathState(this, animator)}, {
                    typeof(JumpState),
                    new JumpState(this, animator, AllServices.Container.Single<IInputService>(), rigidbody2D)
                }
            };
        }

        public void LogicUpdate() {
            ActiveState?.LogicUpdate();
        }

        public void PhysicsUpdate() {
            ActiveState?.PhysicsUpdate();
        }
    }
}