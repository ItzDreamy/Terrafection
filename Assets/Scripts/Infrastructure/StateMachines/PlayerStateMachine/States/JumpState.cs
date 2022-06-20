using Hero;
using Infrastructure.Services.Input;
using UnityEngine;

namespace Infrastructure.StateMachines.PlayerStateMachine.States {
    public class JumpState : IState {
        private readonly MovementStateMachine _stateMachine;
        private readonly HeroAnimator _animator;
        private readonly IInputService _inputService;
        private readonly Rigidbody2D _rigidbody2D;
        private readonly float _jumpHeight;

        public JumpState(MovementStateMachine stateMachine, HeroAnimator animator, IInputService inputService,
            Rigidbody2D rigidbody2D, float jumpHeight) {
            _stateMachine = stateMachine;
            _animator = animator;
            _inputService = inputService;
            _rigidbody2D = rigidbody2D;
            _jumpHeight = jumpHeight;
        }

        public void Exit() { }

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
            movement.y = _jumpHeight;
            _rigidbody2D.velocity = movement;
        }

        public void Enter() {
            Debug.Log("Jumping");
        }
    }
}