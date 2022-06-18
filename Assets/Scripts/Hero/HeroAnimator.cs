using Infrastructure.StateMachines.PlayerStateMachine;
using UnityEngine;

namespace Hero {
    public class HeroAnimator : MonoBehaviour {
        public PlayerStateMachine PlayerStateMachine { get; private set; }

        [SerializeField] private Animator _animator;

        private void Awake() =>
            PlayerStateMachine = new PlayerStateMachine(_animator);
    }
}