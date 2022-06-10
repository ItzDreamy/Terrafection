using Architecture.Services.PersistentProgress;
using Data;
using UnityEngine;

namespace Hero {
    public class HeroMovement : MonoBehaviour, ISavedProgress {
        public void UpdateProgress(PlayerProgress progress) {
            progress.WorldData.Position = transform.position.AsVectorData();
        }

        public void LoadProgress(PlayerProgress progress) {
        }
    }
}