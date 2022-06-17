using UnityEngine;

namespace StaticData.Configs {
    [CreateAssetMenu(fileName = "GenerationConfig", menuName = "StaticData/Generation/GenerationConfig")]
    public class WorldConfig : ScriptableObject {
        [Range(0f, 1f)] public float SurfaceValue;
        [Range(0f, 1000f)] public int WorldSize;
        [Range(0f, 1f)] public float CaveFrequency;
        [Range(0f, 1f)] public float TerrainFrequency;
        [Range(0f, 100f)] public float HeightMultiplier;
        [Range(0f, 100f)] public int HeightAddition;
        [Range(0f, 100f)] public int DirtLayerHeight;
        public int ChunkSize;
    }
}