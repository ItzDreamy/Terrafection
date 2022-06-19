using Hero;
using Infrastructure.Services.Input;
using UnityEngine;

namespace Infrastructure.StateMachines.PlayerStateMachine.States {
    public class IdleState : IState {
        private readonly MovementStateMachine _stateMachine;
        private readonly HeroAnimator _animator;
        private readonly IInputService _inputService;
        private readonly Transform _groundChecker;
        private readonly LayerMask _groundLayer;
        private readonly Rigidbody2D _rigidbody2D;

        public IdleState(MovementStateMachine stateMachine, HeroAnimator animator, IInputService inputService,
            Transform groundChecker, LayerMask layerMask, Rigidbody2D rigidbody2D) {
            _stateMachine = stateMachine;
            _animator = animator;
            _inputService = inputService;
            _groundChecker = groundChecker;
            _groundLayer = layerMask;
            _rigidbody2D = rigidbody2D;
        }

        public void Enter() {
            Debug.Log("Idling");
            _animator.SetAnimatorBool(PlayerAnimatorHashes.IdleHash, true);
        }

        public void Exit() =>
            _animator.SetAnimatorBool(PlayerAnimatorHashes.IdleHash, true);

        public void LogicUpdate() {
            if (_inputService.Axis.x != 0) _stateMachine.Enter<MoveState>();
            else if (_inputService.Axis.y != 0 && IsGrounded()) _stateMachine.Enter<JumpState>();
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