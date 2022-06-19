using UnityEngine;

namespace Hero {
    public class HeroAnimator : MonoBehaviour {
        [SerializeField] private Animator _animator;

        public void SetAnimatorBool(int animationHash, bool value) =>
            _animator.SetBool(animationHash, value);

        public void PlayAnimation(int animationHash) =>
            _animator.Play(animationHash);
    }
}