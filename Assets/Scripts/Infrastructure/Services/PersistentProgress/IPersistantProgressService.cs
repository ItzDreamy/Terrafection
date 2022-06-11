using Data.Player;

namespace Infrastructure.Services.PersistentProgress {
    public interface IPersistantProgressService : IService {
        PlayerProgress Progress { get; set; }
    }
}