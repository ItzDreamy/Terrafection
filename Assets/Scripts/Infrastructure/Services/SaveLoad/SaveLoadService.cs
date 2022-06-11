using Data;
using Data.Player;
using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace Infrastructure.Services.SaveLoad {
    public class SaveLoadService : ISaveLoadService {
        private readonly IGameFactory _gameFactory;
        private readonly IPersistantProgressService _progressService;

        public SaveLoadService(IGameFactory gameFactory, IPersistantProgressService progressService) {
            _gameFactory = gameFactory;
            _progressService = progressService;
        }
        
        public void SaveProgress(string worldName) {
            foreach (var writer in _gameFactory.ProgressWriters) {
                writer.UpdateProgress(_progressService.Progress);
            }
            PlayerPrefs.SetString(worldName, _progressService.Progress.ToJson());
        }

        public PlayerProgress LoadProgress(string worldName) {
            return PlayerPrefs.GetString(worldName)?.ToDeserialized<PlayerProgress>();
        }
    }
}