using UnityEngine;

namespace Infrastructure.StateMachines.PlayerStateMachine {
    public static class PlayerAnimatorHashes {
        public static readonly int DieHash = Animator.StringToHash("Die");
        public static readonly int MoveHash = Animator.StringToHash("Move");
        public static readonly int IdleHash = Animator.StringToHash("Idle");
    }
}