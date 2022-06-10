using Data;

namespace Architecture.Services.SaveLoad {
    public interface ISaveLoadService : IService {
        void SaveProgress(string worldName);
        PlayerProgress LoadProgress(string worldName);
    }
}