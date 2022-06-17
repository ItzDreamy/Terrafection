using System;
using StaticData.Generation;

namespace Data.World {
    [Serializable]
    public class Block {
        public BlockTypeId TypeId;
        public Vector3Data Position;
    }
}