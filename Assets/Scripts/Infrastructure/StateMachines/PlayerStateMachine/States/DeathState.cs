using UnityEngine;

namespace Infrastructure.StateMachines.PlayerStateMachine.States {
    public class DeathState : IState {
        private readonly PlayerStateMachine _stateMachine;
        private readonly Animator _animator;

        public DeathState(PlayerStateMachine stateMachine, Animator animator) {
            _stateMachine = stateMachine;
            _animator = animator;
        }

        public void Enter() =>
            _animator.Play(PlayerAnimatorHashes.DieHash);

        public void Exit() {
        }
    }
}