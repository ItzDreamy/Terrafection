using Hero;
using UnityEngine;

namespace Infrastructure.StateMachines.PlayerStateMachine.States {
    public class DeathState : IState {
        private readonly MovementStateMachine _stateMachine;
        private readonly HeroAnimator _animator;

        public DeathState(MovementStateMachine stateMachine, HeroAnimator animator) {
            _stateMachine = stateMachine;
            _animator = animator;
        }

        public void Enter() =>
            _animator.PlayAnimation(PlayerAnimatorHashes.DieHash);

        public void Exit() { }

        public void LogicUpdate() { }

        public void PhysicsUpdate() { }
    }
}