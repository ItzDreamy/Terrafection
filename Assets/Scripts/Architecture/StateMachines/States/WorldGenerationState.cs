using Architecture.Factory;
using UnityEngine;

namespace Architecture.StateMachines.States {
    public class WorldGenerationState : IState {
        private readonly GameStateMachine _stateMachine;
        private readonly IGameFactory _gameFactory;

        private float _surfaceValue = 0.3f;
        private int _worldSize = 100;
        private float _caveFrequency = 0.065f;
        private float _terrainFrequency = 0.04f;
        private float _heightMultiplier = 25f;
        private int _heightAddition = 25;

        private float _seed;
        private Texture2D _noiseTexture2D;
        private Sprite _tile;

        public WorldGenerationState(GameStateMachine stateMachine, IGameFactory gameFactory) {
            _stateMachine = stateMachine;
            _gameFactory = gameFactory;
        }

        public void Enter() {
            Debug.Log("World generation...");
            _seed = Random.Range(-10000, 10000);
            GenerateNewIfNotExists();
            _stateMachine.Enter<LoadProgressState>();
        }

        public void Exit() {
        }

        private void GenerateNewIfNotExists() {
            //TODO: Try load map
            GenerateTexture();
            GenerateTerrain();
        }

        private void GenerateTexture() {
            _noiseTexture2D = new Texture2D(_worldSize, _worldSize);

            for (int x = 0; x < _noiseTexture2D.width; x++) {
                for (int y = 0; y < _noiseTexture2D.height; y++) {
                    float v = Mathf.PerlinNoise((x + _seed) * _caveFrequency, (y + _seed) * _caveFrequency);
                    _noiseTexture2D.SetPixel(x, y, new Color(v, v, v));
                }
            }

            _noiseTexture2D.Apply();
        }

        private void GenerateTerrain() {
            for (int x = 0; x < _worldSize; x++) {
                float height = Mathf.PerlinNoise((x + _seed) * _terrainFrequency, _seed * _terrainFrequency) *
                    _heightMultiplier + _heightAddition;
                for (int y = 0; y < height; y++) {
                    if (_noiseTexture2D.GetPixel(x, y).r > _surfaceValue) {
                        var position = new Vector2(x + 0.5f, y + 0.5f);
                        var tile = _gameFactory.CreateTile(position);
                    }
                }
            }
        }
    }
}