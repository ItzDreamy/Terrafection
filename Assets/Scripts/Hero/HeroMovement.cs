using Architecture.Services;
using Architecture.Services.Input;
using Architecture.Services.PersistentProgress;
using Architecture.Services.SaveLoad;
using Data;
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
        }

        public void LoadProgress(PlayerProgress progress) {
            if (CurrentLevel() == progress.WorldData.Name) {
                Vector3Data savedPosition = progress.WorldData.PositionOnLevel.Position;
                if (savedPosition != null) {
                    Warp(savedPosition);
                }
            }
        }

        private void Warp(Vector3Data savedPosition) {
            transform.position = savedPosition.AsUnityVector();
        }

        private static string CurrentLevel() {
            return SceneManager.GetActiveScene().name;
        }

        private void OnApplicationQuit() {
            _saveLoadService.SaveProgress("Main");
        }
    }
}