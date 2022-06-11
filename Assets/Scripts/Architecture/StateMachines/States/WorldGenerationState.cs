using Architecture.Factory;
using Architecture.Services.PersistentProgress;
using Architecture.Services.WorldGeneration;
using Configs;
using UnityEngine;

namespace Architecture.StateMachines.States {
    public class WorldGenerationState : IState {
        private readonly GameStateMachine _stateMachine;
        private readonly IGameFactory _gameFactory;
        private readonly IWorldConfigProvider _configProvider;
        private readonly IPersistantProgressService _progressService;
        private readonly WorldConfig _config;
        private Transform _terrainParent;

        private float _seed;
        private Texture2D _noiseTexture2D;

        public WorldGenerationState(GameStateMachine stateMachine, IGameFactory gameFactory,
            IWorldConfigProvider configProvider, IPersistantProgressService progressService) {
            _stateMachine = stateMachine;
            _gameFactory = gameFactory;
            _configProvider = configProvider;
            _progressService = progressService;
            _config = _configProvider.Config;
        }

        public void Enter() {
            _seed = Random.Range(-10000, 10000);
            GenerateNewIfNotExists();
            _stateMachine.Enter<InitializationPlayerState>();
        }

        public void Exit() {
        }

        private void GenerateNewIfNotExists() {
            _terrainParent = _gameFactory.CreateWorldParent().transform;
            if (_progressService.Progress.WorldData.BlocksPositions != null) {
                return;
            }
            GenerateTexture();
            GenerateTerrain();
        }

        private void GenerateTexture() {
            _noiseTexture2D = new Texture2D(_config.WorldSize, _config.WorldSize);

            for (int x = 0; x < _noiseTexture2D.width; x++) {
                for (int y = 0; y < _noiseTexture2D.height; y++) {
                    float v = Mathf.PerlinNoise((x + _seed) * _config.CaveFrequency,
                        (y + _seed) * _config.CaveFrequency);
                    _noiseTexture2D.SetPixel(x, y, new Color(v, v, v));
                }
            }

            _noiseTexture2D.Apply();
        }

        private void GenerateTerrain() {
            for (int x = 0; x < _config.WorldSize; x++) {
                float height =
                    Mathf.PerlinNoise((x + _seed) * _config.TerrainFrequency, _seed * _config.TerrainFrequency) *
                    _config.HeightMultiplier + _config.HeightAddition;
                for (int y = 0; y < height; y++) {
                    if (_noiseTexture2D.GetPixel(x, y).r > _config.SurfaceValue) {
                        var position = new Vector2(x + 0.5f, y + 0.5f);
                        var tile = _gameFactory.CreateTile(position, _terrainParent);
                    }
                }
            }
        }
    }
}