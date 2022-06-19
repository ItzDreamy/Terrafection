using UnityEngine;

namespace Hero {
    public class HeroAnimator : MonoBehaviour {
        [SerializeField] private Animator _animator;
        public Animator Animator => _animator;

        private void Awake() {
        }
    }
}