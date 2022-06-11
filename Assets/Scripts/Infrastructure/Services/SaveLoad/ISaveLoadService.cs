using Data.Player;

namespace Infrastructure.Services.SaveLoad {
    public interface ISaveLoadService : IService {
        void SaveProgress(string worldName);
        PlayerProgress LoadProgress(string worldName);
    }
}