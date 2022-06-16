using StaticData.Configs;
using UnityEngine;

namespace Infrastructure.Services.WorldGeneration {
    public class WorldConfigProvider : IWorldConfigProvider {
        public WorldConfig Config =>
            Resources.Load<WorldConfig>("StaticData/Configs/GenerationConfig");
    }
} 