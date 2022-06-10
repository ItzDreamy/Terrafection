using Architecture.Scripts.AssetManagement;
using UnityEngine;

namespace Architecture.Scripts.Factory {
    public class GameFactory : IGameFactory {
        private readonly IAssetProvider _assets;

        public GameFactory(IAssetProvider assets) {
            _assets = assets;
        }

        public GameObject CreateHero(Vector2 at) {
            return _assets.Instantiate(AssetPath.HeroPath, at);
        }

        public void CreateHud() {
            _assets.Instantiate(AssetPath.HudPath);
        }
    }
}