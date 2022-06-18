using System;
using System.Collections.Generic;

namespace Data.World {
    [Serializable]
    public class Chunk {
        public List<BlockSaveData> Blocks;
    }
}