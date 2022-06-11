using Architecture.Services;
using Architecture.Services.Input;
using Architecture.Services.PersistentProgress;
using Architecture.Services.SaveLoad;
using Data;
using Data.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hero {
    public class HeroMovement : MonoBehaviour, ISavedProgress {
        private IInputService _inputService;
        private ISaveLoadService _saveLoadService;

        private void Awake() {
            _inputService = AllServices.Container.Single<IInputService>();
            _saveLoadService = AllServices.Container.Single<ISaveLoadService>();
        }

        private void Update() {
            var inputAxis = _inputService.Axis;
            if (inputAxis.sqrMagnitude > 0.001f) {
                Debug.Log(inputAxis);
            }
        }

        public void UpdateProgress(PlayerProgress progress) {
            progress.WorldData.PositionOnLevel =
                new PositionOnLevel(transform.position.AsVectorData());
            
            Debug.Log("Player position saved.");
        }

        public void LoadProgress(PlayerProgress progress) {
            Vector3Data savedPosition = progress.WorldData.PositionOnLevel.Position;
            if (savedPosition != null) {
                Warp(savedPosition);
            }
        }

        private void Warp(Vector3Data savedPosition) {
            transform.position = savedPosition.AsUnityVector();
        }

        private void OnApplicationQuit() {
            _saveLoadService.SaveProgress("Main");
        }
    }
}