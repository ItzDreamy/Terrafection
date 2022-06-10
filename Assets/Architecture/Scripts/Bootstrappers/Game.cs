using Architecture.Scripts.Services;
using Architecture.Scripts.StateMachines;

namespace Architecture.Scripts.Bootstrappers {
    public class Game {
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner) {
            var sceneLoader = new SceneLoader(coroutineRunner);
            StateMachine = new GameStateMachine(sceneLoader, AllServices.Container);
        }
    }
}