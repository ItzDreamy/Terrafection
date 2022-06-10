using System;

namespace Data {
    [Serializable]
    public class WorldData {
        public string Name;
        public PositionOnLevel PositionOnLevel;

        public WorldData(string worldName) {
            Name = worldName;
            PositionOnLevel = new PositionOnLevel(new Vector3Data(0, 0, 0));
        }
    }
}