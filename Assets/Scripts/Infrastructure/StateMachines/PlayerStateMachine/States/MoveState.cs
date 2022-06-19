using Hero;
using Infrastructure.Services.Input;
using UnityEngine;

namespace Infrastructure.StateMachines.PlayerStateMachine.States {
    public class MoveState : IState {
        private readonly PlayerStateMachine _stateMachine;
        private readonly Animator _animator;
        private readonly IInputService _inputService;
        private readonly Rigidbody2D _rigidbody2D;
        private readonly Transform _groundChecker;
        private readonly LayerMask _groundLayer;

        public MoveState(PlayerStateMachine stateMachine, HeroAnimator animator, IInputService inputService,
            Rigidbody2D rigidbody2D, Transform groundChecker, LayerMask groundLayer) {
            _stateMachine = stateMachine;
            _animator = animator.Animator;
            _inputService = inputService;
            _rigidbody2D = rigidbody2D;
            _groundChecker = groundChecker;
            _groundLayer = groundLayer;
        }

        public void Enter() =>
            _animator.SetBool(PlayerAnimatorHashes.MoveHash, true);

        public void Exit() =>
            _animator.SetBool(PlayerAnimatorHashes.MoveHash, false);

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

        public void PhysicsUpdate() {
            Vector2 inputAxis = _inputService.Axis;
            Vector2 movement = new Vector2(inputAxis.x * 5, _rigidbody2D.velocity.y);
            _rigidbody2D.velocity = movement;
        }
    }
}