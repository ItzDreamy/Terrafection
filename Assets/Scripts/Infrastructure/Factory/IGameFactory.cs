using System.Collections.Generic;
using Data.World;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using StaticData.Generation;
using UnityEngine;

namespace Infrastructure.Factory {
    public interface IGameFactory : IService {
        GameObject CreateHero(Vector2 at);
        void CreateHud();
        GameObject CreateTile(BlockTypeId typeId, Vector3 at, int chunkIndex, Transform parent);
        GameObject CreateChunk(int index, Transform parent);
        GameObject CreateWorldParent();
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }
        public GameObject WorldParent { get; }
        void Cleanup();
    }
}