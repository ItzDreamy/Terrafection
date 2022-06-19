using Hero;
using Infrastructure.Services.Input;
using UnityEngine;

namespace Infrastructure.StateMachines.PlayerStateMachine.States {
    public class IdleState : IState {
        private readonly PlayerStateMachine _stateMachine;
        private readonly IInputService _inputService;
        private readonly Animator _animator;
        private readonly Transform _groundChecker;
        private readonly LayerMask _groundLayer;
        private readonly Rigidbody2D _rigidbody2D;

        public IdleState(PlayerStateMachine stateMachine, HeroAnimator animator, IInputService inputService,
            Transform groundChecker, LayerMask layerMask, Rigidbody2D rigidbody2D) {
            _stateMachine = stateMachine;
            _inputService = inputService;
            _groundChecker = groundChecker;
            _groundLayer = layerMask;
            _rigidbody2D = rigidbody2D;
            _animator = animator.Animator;
        }

        public void Enter() {
            _animator.SetBool(PlayerAnimatorHashes.IdleHash, true);
        }

        public void Exit() =>
            _animator.SetBool(PlayerAnimatorHashes.IdleHash, true);

        public void LogicUpdate() {
            if (_inputService.Axis.x != 0) {
                _stateMachine.Enter<MoveState>();
            }
            else if (_inputService.Axis.y != 0 && IsGrounded()) {
                _stateMachine.Enter<JumpState>();
            }
        }

        private bool IsGrounded() =>
            Physics2D.OverlapCircle(_groundChecker.position, 0.15f, _groundLayer) != null;

        public void PhysicsUpdate() {
            Vector2 idleMovement = _rigidbody2D.velocity;
            idleMovement.x = 0;
            _rigidbody2D.velocity = idleMovement;
        }
    }
}