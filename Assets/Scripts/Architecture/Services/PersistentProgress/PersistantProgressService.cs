using Data.Player;

namespace Architecture.Services.PersistentProgress {
    public class PersistantProgressService : IPersistantProgressService {
        public PlayerProgress Progress { get; set; }
    }
}