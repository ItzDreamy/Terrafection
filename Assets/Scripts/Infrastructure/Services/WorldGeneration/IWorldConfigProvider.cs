using StaticData.Configs;

namespace Infrastructure.Services.WorldGeneration {
    public interface IWorldConfigProvider : IService {
        void LoadConfig();
        WorldConfig Config { get; }
    }
}