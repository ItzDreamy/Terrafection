using Architecture.Scripts.Services;
using UnityEngine;

namespace Architecture.Scripts.Factory {
    public interface IGameFactory : IService {
        GameObject CreateHero(Vector2 at);
        void CreateHud();
    }
}