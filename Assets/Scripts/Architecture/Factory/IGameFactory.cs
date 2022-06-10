using Architecture.Services;
using UnityEngine;

namespace Architecture.Factory {
    public interface IGameFactory : IService {
        GameObject CreateHero(Vector2 at);
        void CreateHud();
    }
}