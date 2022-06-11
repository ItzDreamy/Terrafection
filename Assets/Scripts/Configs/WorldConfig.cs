using System;

namespace Configs {
    [Serializable]
    public class WorldConfig {
        public float SurfaceValue;
        public int WorldSize;
        public float CaveFrequency;
        public float TerrainFrequency;
        public float HeightMultiplier;
        public int HeightAddition;
    }
}