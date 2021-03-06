using Hero;
using Infrastructure.Services.Input;
using UnityEngine;

namespace Infrastructure.StateMachines.PlayerStateMachine.States {
    public class MoveState : IState {
        private readonly MovementStateMachine _stateMachine;
        private readonly HeroAnimator _animator;
        private readonly IInputService _inputService;
        private readonly Rigidbody2D _rigidbody2D;
        private readonly Transform _groundChecker;
        private readonly LayerMask _groundLayer;
        private readonly float _speed;

        public MoveState(MovementStateMachine stateMachine, HeroAnimator animator, IInputService inputService,
            Rigidbody2D rigidbody2D, Transform groundChecker, LayerMask groundLayer, float speed) {
            _stateMachine = stateMachine;
            _animator = animator;
            _inputService = inputService;
            _rigidbody2D = rigidbody2D;
            _groundChecker = groundChecker;
            _groundLayer = groundLayer;
            _speed = speed;
        }

        public void Enter() {
            Debug.Log("Moving");
            _animator.SetAnimatorBool(PlayerAnimatorHashes.MoveHash, true);
        }

        public void Exit() =>
            _animator.SetAnimatorBool(PlayerAnimatorHashes.MoveHash, false);

        public void PhysicsUpdate() {
            Vector2 inputAxis = _inputService.Axis;
            Vector2 movement = new Vector2(inputAxis.x * _speed, _rigidbody2D.velocity.y);
            _rigidbody2D.velocity = movement;
            Flip();
        }

        public void LogicUpdate() {
            if (_inputService.Axis.y != 0 && IsGrounded()) {
                _stateMachine.Enter<JumpState>();
            }
            else if (_inputService.Axis.x == 0 && _inputService.Axis.y == 0) {
                _stateMachine.Enter<IdleState>();
            }
        }

        private bool IsGrounded() =>
            Physics2D.OverlapCircle(_groundChecker.position, 0.15f, _groundLayer) != null;

        private void Flip() =>
            _rigidbody2D.transform.localScale = _inputService.Axis.x > 0 ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);
    }
}