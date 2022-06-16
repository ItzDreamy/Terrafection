using StaticData.Generation;

namespace Infrastructure.Services.WorldGeneration {
    public interface IBlocksDataProvider : IService {
        void LoadBlocks();
        BlockData GetBlockData(BlockTypeId id);
    }
}