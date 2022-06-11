using Configs;

namespace Architecture.Services.WorldGeneration {
    public interface IWorldConfigProvider : IService {
        WorldConfig Config { get; }
    }
}