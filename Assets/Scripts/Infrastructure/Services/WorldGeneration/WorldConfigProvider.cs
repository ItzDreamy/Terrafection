using StaticData.Configs;
using UnityEngine;

namespace Infrastructure.Services.WorldGeneration {
    public class WorldConfigProvider : IWorldConfigProvider {
        private WorldConfig _config;

        public void LoadConfig() {
            _config = Resources.Load<WorldConfig>("StaticData/Configs/GenerationConfig");
        }

        public WorldConfig Config =>
            _config;
    }
}