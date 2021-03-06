using System.Collections.Generic;
using Data;
using Data.World;
using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.WorldGeneration;
using StaticData.Generation;
using UnityEngine;

namespace Infrastructure.Factory {
    public class GameFactory : IGameFactory {
        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();
        public GameObject WorldParent { get; private set; }
        private readonly IAssetProvider _assets;
        private readonly IBlocksDataProvider _blocksDataProvider;


        public GameFactory(IAssetProvider assets, IBlocksDataProvider blocksDataProvider) {
            _assets = assets;
            _blocksDataProvider = blocksDataProvider;
        }

        public GameObject CreateWorldParent() {
            var obj = new GameObject(name: "Terrain");
            obj.AddComponent<World.Terrain>();
            RegisterProgressWatchers(obj);
            WorldParent = obj;
            return obj;
        }

        public GameObject CreateHero(Vector2 at) =>
            InstantiateRegistered(at, AssetPath.HeroPath);

        public void CreateHud() =>
            InstantiateRegistered(AssetPath.HudPath);

        public GameObject CreateChunk(int index, Transform parent) =>
            new(name: index.ToString()) {
                transform = {
                    parent = parent
                }
            };

        public GameObject CreateTile(BlockTypeId typeId, Vector3 at, int chunkIndex, Transform parent) {
            BlockData blockData = _blocksDataProvider.GetBlockData(typeId);
            var block = new BlockSaveData {
                Position = at.AsVectorData(),
                TypeId = typeId
            };
            return Object.Instantiate(blockData.BlockPrefab, at, Quaternion.identity, parent);
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

        private GameObject InstantiateRegistered(Vector2 at, Transform parent, string prefabPath) {
            var gameObject = _assets.Instantiate(prefabPath, at, parent);
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