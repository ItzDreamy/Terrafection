using Data.Player;

namespace Architecture.Services.PersistentProgress {
    public interface IPersistantProgressService : IService {
        PlayerProgress Progress { get; set; }
    }
}