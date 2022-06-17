using System;
using System.Collections.Generic;
using Data.Player;

namespace Data.World {
    [Serializable]
    public class WorldData {
        public string Name;
        public PositionOnLevel PositionOnLevel;
        public List<Chunk> Chunks;

        public WorldData(string worldName) {
            Name = worldName;
            PositionOnLevel = new PositionOnLevel(new Vector3Data(0, 0, 0));
        }
    }
}