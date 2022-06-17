using System.Collections.Generic;
using Data;
using Data.Player;
using Data.World;
using Infrastructure.Factory;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using StaticData.Generation;
using UnityEngine;

namespace World {
    public class World : MonoBehaviour, ISavedProgress {
        private IGameFactory _gameFactory;

        private void Awake() {
            _gameFactory = AllServices.Container.Single<IGameFactory>();
        }

        public void LoadProgress(PlayerProgress progress) {
            var blocks = progress.WorldData.Blocks;
            if (blocks == null) {
                return;
            }

            foreach (var block in blocks) {
                _gameFactory
                    .CreateTile(block.TypeId, block.Position.AsUnityVector(), transform);
            }

            Debug.Log("Saved world loaded.");
        }

        public void UpdateProgress(PlayerProgress progress) {
            progress.WorldData.Blocks = new List<Block>();
            foreach (Block block in _gameFactory.Blocks) {
                progress.WorldData.Blocks.Add(block);
            }

            Debug.Log("World saved.");
        }
    }
}