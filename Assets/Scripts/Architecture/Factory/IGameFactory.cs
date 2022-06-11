using System.Collections.Generic;
using Architecture.Services;
using Architecture.Services.PersistentProgress;
using UnityEngine;

namespace Architecture.Factory {
    public interface IGameFactory : IService {
        GameObject CreateHero(Vector2 at);
        void CreateHud();
        GameObject CreateTile(Vector2 at, Transform parent);
        GameObject CreateWorldParent();
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }
        void Cleanup();
    }
}