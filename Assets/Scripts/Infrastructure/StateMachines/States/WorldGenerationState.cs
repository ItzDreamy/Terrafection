using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.WorldGeneration;
using StaticData.Configs;
using StaticData.Generation;
using UnityEngine;

namespace Infrastructure.StateMachines.States {
    public class WorldGenerationState : IState {
        private readonly GameStateMachine _stateMachine;
        private readonly IGameFactory _gameFactory;
        private readonly IWorldConfigProvider _configProvider;
        private readonly IPersistantProgressService _progressService;
        private readonly WorldConfig _config;
        private Transform _terrainParent;

        private float _seed;
        private Texture2D _noiseTexture2D;
        private GameObject[] _chunks;

        private Vector2 _spawnPosition;

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

            _terrainParent = CreateTerrainParent();
            if (_progressService.Progress.WorldData.Chunks == null) {
                GenerateNewWorld();
            }
            
            _stateMachine.Enter<InitializationPlayerState, Vector2>(_spawnPosition);
        }

        public void Exit() {
        }

        private void GenerateNewWorld() {
            CreateChunks();
            GenerateTexture();
            GenerateTerrain();
        }

        private Transform CreateTerrainParent() =>
            _gameFactory.CreateWorldParent().transform;

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
                var height = CalculateHeight(x);

                if (x == _config.WorldSize / 2) {
                    _spawnPosition = new Vector2(x, height + 1);
                }

                for (int y = 0; y < height; y++) {
                    if (IsNotCave(x, y)) {
                        CreateBlock(x, y, SwitchBlockType(y, height));
                    }
                }
            }
        }

        private void CreateChunks() {
            int chunksCount = (int) Mathf.Ceil((float) _config.WorldSize / _config.ChunkSize);
            _chunks = new GameObject[chunksCount];

            for (int i = 0; i < chunksCount; i++) {
                var newChunk = _gameFactory.CreateChunk(i, _terrainParent);
                _chunks[i] = newChunk;
            }
        }

        private void CreateBlock(int x, int y, BlockTypeId typeId) {
            int chunkCoord = Mathf.RoundToInt(x / _config.ChunkSize) * _config.ChunkSize;
            chunkCoord /= _config.ChunkSize;
            _gameFactory.CreateTile(typeId, new Vector2(x + 0.5f, y + 0.5f), chunkCoord, _chunks[chunkCoord].transform);
        }

        private BlockTypeId SwitchBlockType(int y, float height) {
            BlockTypeId typeId;

            if (IsStone(y, height)) {
                typeId = BlockTypeId.Stone;
            }
            else if (IsDirt(y, height)) {
                typeId = BlockTypeId.Dirt;
            }
            else {
                typeId = BlockTypeId.Grass;
            }

            return typeId;
        }

        private bool IsDirt(int y, float height) =>
            y < height - 1;

        private bool IsStone(int y, float height) =>
            y < height - _config.DirtLayerHeight;

        private bool IsNotCave(int x, int y) =>
            _noiseTexture2D.GetPixel(x, y).r > _config.SurfaceValue;

        private float CalculateHeight(int x) =>
            Mathf.PerlinNoise((x + _seed) * _config.TerrainFrequency, _seed * _config.TerrainFrequency) *
            _config.HeightMultiplier + _config.HeightAddition;
    }
}