﻿using Hero;
using Infrastructure.Services.Input;
using UnityEngine;

namespace Infrastructure.StateMachines.PlayerStateMachine.States {
    public class JumpState : IState {
        private readonly PlayerStateMachine _stateMachine;
        private readonly HeroAnimator _animator;
        private readonly IInputService _inputService;
        private readonly Rigidbody2D _rigidbody2D;

        public JumpState(PlayerStateMachine stateMachine, HeroAnimator animator, IInputService inputService,
            Rigidbody2D rigidbody2D) {
            _stateMachine = stateMachine;
            _animator = animator;
            _inputService = inputService;
            _rigidbody2D = rigidbody2D;
        }

        public void Exit() {
        }

        public void LogicUpdate() {
            if (_inputService.Axis.x != 0) {
                _stateMachine.Enter<MoveState>();
            }
            else {
                _stateMachine.Enter<IdleState>();
            }
        }

        public void PhysicsUpdate() {
            Vector2 movement = _rigidbody2D.velocity;
            movement.y = 11;
            _rigidbody2D.velocity = movement;
        }

        public void Enter() {
        }
    }
}