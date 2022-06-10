using System.Collections.Generic;
using Architecture.Services;
using Architecture.Services.PersistentProgress;
using UnityEngine;

namespace Architecture.Factory {
    public interface IGameFactory : IService {
        GameObject CreateHero(Vector2 at);
        void CreateHud();
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }
        void Cleanup();
    }
}