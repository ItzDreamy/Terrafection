using System;
using Data.World;

namespace Data.Player {
    [Serializable]
    public class PlayerProgress {
        public WorldData WorldData;
        public Vector3Data Position;
        public Stats Stats;

        public PlayerProgress(string worldName) {
            WorldData = new WorldData(worldName);
            Position = new Vector3Data(0, 0, 0);
            Stats = new Stats();
        }
    }
}