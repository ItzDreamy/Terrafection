using Data;

namespace Architecture.Services.PersistentProgress {
    public class PersistantProgressService : IPersistantProgressService {
        public PlayerProgress Progress { get; set; }
    }
}