using System;
using Data.World;

namespace Data.Player {
    [Serializable]
    public class PlayerProgress {
        public WorldData WorldData;

        public PlayerProgress(string worldName) {
            WorldData = new WorldData(worldName);
        }
    }
}