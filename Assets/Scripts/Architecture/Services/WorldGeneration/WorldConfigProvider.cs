using System.IO;
using Configs;
using UnityEngine;

namespace Architecture.Services.WorldGeneration {
    public class WorldConfigProvider : IWorldConfigProvider {
        public WorldConfig Config {
            get {
                string json = File.ReadAllText(Path.Combine(Application.streamingAssetsPath, "Configs",
                    "WorldGenerationConfig.json"));

                return JsonUtility.FromJson<WorldConfig>(json);
            }
        }
    }
}