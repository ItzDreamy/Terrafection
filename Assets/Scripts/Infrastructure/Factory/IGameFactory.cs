using System.Collections.Generic;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace Infrastructure.Factory {
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