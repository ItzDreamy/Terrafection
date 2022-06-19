using Hero;
using UnityEngine;

namespace Infrastructure.StateMachines.PlayerStateMachine.States {
    public class DeathState : IState {
        private readonly PlayerStateMachine _stateMachine;
        private readonly Animator _animator;

        public DeathState(PlayerStateMachine stateMachine, HeroAnimator animator) {
            _stateMachine = stateMachine;
            _animator = animator.Animator;
        }

        public void Enter() =>
            _animator.SetBool(PlayerAnimatorHashes.DieHash, true);

        public void Exit() =>
            _animator.SetBool(PlayerAnimatorHashes.DieHash, false);

        public void LogicUpdate() {
        }

        public void PhysicsUpdate() {
        }
    }
}