using UnityEngine;

namespace Infrastructure.StateMachines.PlayerStateMachine.States {
    public class MoveState : IState {
        private readonly PlayerStateMachine _stateMachine;
        private readonly Animator _animator;

        public MoveState(PlayerStateMachine stateMachine, Animator animator) {
            _stateMachine = stateMachine;
            _animator = animator;
        }

        public void Enter() =>
            _animator.SetBool(PlayerAnimatorHashes.MoveHash, true);

        public void Exit() =>
            _animator.SetBool(PlayerAnimatorHashes.MoveHash, false);
    }
}