using System;
using System.Collections.Generic;
using Data.Player;

namespace Data.World {
    [Serializable]
    public class WorldData {
        public string Name;
        public List<Chunk> Chunks;

        public WorldData(string worldName) {
            Name = worldName;
        }
    }
}