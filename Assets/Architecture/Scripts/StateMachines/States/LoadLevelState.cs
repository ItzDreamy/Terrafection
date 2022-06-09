using UnityEngine;

namespace Architecture.Scripts.StateMachines.States {
    public class LoadLevelState : IPayloadedState<string> {
        private const string Hud = "Hud/Hud";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader) {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName) => _sceneLoader.Load(sceneName, onLoaded: OnLoaded);

        public void Exit() {
        }

        private void OnLoaded() {
            //TODO: Spawn player
            Instantiate(Hud);
        }

        private static GameObject Instantiate(string path) {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }
        
        private static GameObject Instantiate(string path, Vector2 at) {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }
    }
}