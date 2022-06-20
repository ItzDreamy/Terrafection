using Data;
using Data.Player;
using Infrastructure.Services;
using Infrastructure.Services.Input;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using Infrastructure.StateMachines.PlayerStateMachine;
using Infrastructure.StateMachines.PlayerStateMachine.States;
using UnityEngine;

namespace Hero {
    [RequireComponent(typeof(Rigidbody2D))]
    public class HeroMovement : MonoBehaviour, ISavedProgress {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Transform _groundChecker;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private HeroAnimator _heroAnimator;

        private ISaveLoadService _saveLoadService;
        private MovementStateMachine _stateMachine;
        private PlayerProgress _progress;

        private void Awake() {
            _saveLoadService = AllServices.Container.Single<ISaveLoadService>();
        }

        private void Update() {
            _stateMachine.LogicUpdate();
        }

        private void FixedUpdate() => _stateMachine.PhysicsUpdate();

        private void OnApplicationQuit() => _saveLoadService.SaveProgress("Main");

        public void UpdateProgress(PlayerProgress progress) {
            progress.Position =
                transform.position.AsVectorData();

            Debug.Log("Player position saved.");
        }

        public void LoadProgress(PlayerProgress progress) {
            _progress = progress;
            Vector3Data savedPosition = progress.Position;
            if (savedPosition != null && !(savedPosition.X == 0 && savedPosition.Y == 0)) {
                Warp(savedPosition);
            }
            
            InitializeStateMachine();
        }

        private void InitializeStateMachine() {
            _stateMachine = new MovementStateMachine(_heroAnimator, _rigidbody, _groundChecker, _groundLayer, _progress.Stats);
            _stateMachine.Enter<IdleState>();
        }

        private void Warp(Vector3Data savedPosition) =>
            transform.position = savedPosition.AsUnityVector();
    }
}