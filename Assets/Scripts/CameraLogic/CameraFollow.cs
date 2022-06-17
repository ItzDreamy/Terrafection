using UnityEngine;

namespace CameraLogic {
    public class CameraFollow : MonoBehaviour {
        [SerializeField] private float _smoothTime;
        private Transform _following;

        private void FixedUpdate() {
            if (_following == null) {
                return;
            }

            Vector3 position = transform.position;
            position.x = Mathf.Lerp(position.x, _following.position.x, _smoothTime * Time.deltaTime);
            position.y = Mathf.Lerp(position.y, _following.position.y, _smoothTime * Time.deltaTime);

            transform.position = position;
        }

        public void Follow(GameObject target) =>
            _following = target.transform;
    }
}