using Architecture.AssetManagement;
using UnityEngine;

namespace Architecture.Factory {
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