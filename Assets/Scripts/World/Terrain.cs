using System.Collections.Generic;
using Data;
using Data.Player;
using Data.World;
using Infrastructure.Factory;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace World {
    public class Terrain : MonoBehaviour, ISavedProgress {
        private IGameFactory _gameFactory;

        private void Awake() {
            _gameFactory = AllServices.Container.Single<IGameFactory>();
        }

        public void LoadProgress(PlayerProgress progress) {
            var chunks = progress.WorldData.Chunks;
            if (chunks == null || chunks.Count == 0) {
                return;
            }

            for (var i = 0; i < chunks.Count; i++) {
                var newChunk = _gameFactory.CreateChunk(i, transform);
                Transform chunkTransform = newChunk.transform;
                Chunk chunk = chunks[i];

                foreach (var block in chunk.Blocks) {
                    _gameFactory
                        .CreateTile(block.TypeId, block.Position.AsUnityVector(), i, chunkTransform);
                }
            }

            Debug.Log("Saved world loaded.");
        }


        public void UpdateProgress(PlayerProgress progress) {
            progress.WorldData.Chunks = new List<Chunk>();

            foreach (Transform chunkTransform in transform) {
                Chunk chunk = new Chunk {
                    Blocks = new List<BlockSaveData>()
                };

                foreach (Transform blockTransform in chunkTransform) {
                    if (blockTransform.TryGetComponent(out Block block)) {
                        BlockSaveData blockSaveData = new BlockSaveData {
                            Position = blockTransform.position.AsVectorData(),
                            TypeId = block.Data.BlockTypeId
                        };

                        chunk.Blocks.Add(blockSaveData);
                    }
                }

                progress.WorldData.Chunks.Add(chunk);
            }

            Debug.Log("World saved.");
        }
    }
}