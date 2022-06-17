using Data;
using Data.Player;
using Infrastructure.Services;
using Infrastructure.Services.Input;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace Hero {
    [RequireComponent(typeof(Rigidbody2D))]
    public class HeroMovement : MonoBehaviour, ISavedProgress {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Transform _groundChecker;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _jumpHeight;
        [SerializeField] private float _movementSpeed;

        private IInputService _inputService;
        private ISaveLoadService _saveLoadService;
        private Vector2 _inputAxis;

        private void Awake() {
            _inputService = AllServices.Container.Single<IInputService>();
            _saveLoadService = AllServices.Container.Single<ISaveLoadService>();
        }

        private void Update() {
            _inputAxis = _inputService.Axis;
        }

        private void FixedUpdate() {
            if (_inputAxis.sqrMagnitude > 0.001f) {
                Vector2 movement = new Vector2(_inputAxis.x * _movementSpeed, _rigidbody.velocity.y);

                if (IsJump(_inputAxis) && IsGrounded()) {
                    movement.y = _jumpHeight;
                }

                _rigidbody.velocity = movement;

                Flip();
            }
        }

        private bool IsJump(Vector2 axis) =>
            axis.y > 0.1f;

        private void Flip() =>
            transform.localScale = _inputAxis.x > 0 ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);

        private void OnApplicationQuit() {
            _saveLoadService.SaveProgress("Main");
        }

        public void UpdateProgress(PlayerProgress progress) {
            progress.WorldData.PositionOnLevel =
                new PositionOnLevel(transform.position.AsVectorData());

            Debug.Log("Player position saved.");
        }

        public void LoadProgress(PlayerProgress progress) {
            Vector3Data savedPosition = progress.WorldData.PositionOnLevel.Position;
            if (savedPosition != null && !(savedPosition.X == 0 && savedPosition.Y == 0)) {
                Warp(savedPosition);
            }
        }

        private bool IsGrounded() =>
            Physics2D.OverlapCircle(_groundChecker.position, 0.15f, _groundLayer) != null;

        private void Warp(Vector3Data savedPosition) =>
            transform.position = savedPosition.AsUnityVector();
    }
}