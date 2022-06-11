using Configs;

namespace Infrastructure.Services.WorldGeneration {
    public interface IWorldConfigProvider : IService {
        WorldConfig Config { get; }
    }
}