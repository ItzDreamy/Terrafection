using System;
using StaticData.Generation;

namespace Data.World {
    [Serializable]
    public class BlockSaveData {
        public BlockTypeId TypeId;
        public Vector3Data Position;
    }
}