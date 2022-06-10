using System;

namespace Data {
    [Serializable]
    public class PlayerProgress {
        public WorldData WorldData;

        public PlayerProgress(string worldName) {
            WorldData = new WorldData(worldName);
        }
    }
}