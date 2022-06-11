using Data.Player;

namespace Infrastructure.Services.PersistentProgress {
    public class PersistantProgressService : IPersistantProgressService {
        public PlayerProgress Progress { get; set; }
    }
}