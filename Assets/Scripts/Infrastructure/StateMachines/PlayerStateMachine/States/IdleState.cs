using UnityEngine;

namespace Infrastructure.StateMachines.PlayerStateMachine.States {
    public class IdleState : IState {
        private readonly PlayerStateMachine _stateMachine;
        private readonly Animator _animator;

        public IdleState(PlayerStateMachine stateMachine, Animator animator) {
            _stateMachine = stateMachine;
            _animator = animator;
        }

        public void Enter() =>
            _animator.SetTrigger(PlayerAnimatorHashes.IdleHash);

        public void Exit() =>
            _animator.ResetTrigger(PlayerAnimatorHashes.IdleHash);
    }
}