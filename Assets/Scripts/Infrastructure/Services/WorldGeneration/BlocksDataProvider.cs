using System.Collections.Generic;
using System.Linq;
using StaticData.Generation;
using UnityEngine;

namespace Infrastructure.Services.WorldGeneration {
    public class BlocksDataProvider : IBlocksDataProvider {
        private Dictionary<BlockTypeId, BlockData> _blocks;

        public void LoadBlocks() {
            _blocks = Resources
                .LoadAll<BlockData>("StaticData/Generation")
                .ToDictionary(x => x.BlockTypeId, x => x);
        }

        public BlockData GetBlockData(BlockTypeId id) =>
            _blocks.TryGetValue(id, out BlockData blockData) ? blockData : null;
    }
}