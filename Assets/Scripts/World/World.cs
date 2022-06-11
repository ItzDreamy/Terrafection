using System.Collections.Generic;
using Architecture.Factory;
using Architecture.Services;
using Architecture.Services.PersistentProgress;
using Data;
using Data.Player;
using UnityEngine;

namespace World {
    public class World : MonoBehaviour, ISavedProgress {
        private IGameFactory _gameFactory;

        private void Awake() {
            _gameFactory = AllServices.Container.Single<IGameFactory>();
        }

        public void LoadProgress(PlayerProgress progress) {
            var blocksPositions = progress.WorldData.BlocksPositions;
            if (blocksPositions == null) {
                return;
            }
            
            foreach (var blockPosition in blocksPositions) {
                _gameFactory.CreateTile(blockPosition.AsUnityVector(), transform);
            }

            Debug.Log("Saved world loaded.");
        }

        public void UpdateProgress(PlayerProgress progress) {
            progress.WorldData.BlocksPositions = new List<Vector3Data>();
            foreach (Transform child in transform) {
                progress.WorldData.BlocksPositions.Add(child.position.AsVectorData());
            }

            Debug.Log("World saved.");
        }
    }
}