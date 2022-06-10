using Data;

namespace Architecture.Services.PersistentProgress {
    public interface IPersistantProgressService : IService {
        PlayerProgress Progress { get; set; }
    }
}