using System.Collections.Generic;
using Architecture.AssetManagement;
using Architecture.Services.PersistentProgress;
using UnityEngine;

namespace Architecture.Factory {
    public class GameFactory : IGameFactory {
        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();

        private readonly IAssetProvider _assets;

        public GameFactory(IAssetProvider assets) {
            _assets = assets;
        }

        public GameObject CreateHero(Vector2 at) => InstantiateRegistered(at, AssetPath.HeroPath);

        public void CreateHud() {
            InstantiateRegistered(AssetPath.HudPath);
        }

        public void Cleanup() {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        private GameObject InstantiateRegistered(Vector2 at, string prefabPath) {
            var gameObject = _assets.Instantiate(prefabPath, at);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }

        private GameObject InstantiateRegistered(string prefabPath) {
            var gameObject = _assets.Instantiate(prefabPath);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }

        private void RegisterProgressWatchers(GameObject gameObject) {
            foreach (var reader in gameObject.GetComponentsInChildren<ISavedProgressReader>()) {
                Register(reader);
            }
        }

        private void Register(ISavedProgressReader reader) {
            if (reader is ISavedProgress progressWriter) {
                ProgressWriters.Add(progressWriter);
            }

            ProgressReaders.Add(reader);
        }
    }
}