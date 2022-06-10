using Architecture.Services;
using Architecture.StateMachines;

namespace Architecture.Bootstrappers {
    public class Game {
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner) {
            var sceneLoader = new SceneLoader(coroutineRunner);
            StateMachine = new GameStateMachine(sceneLoader, AllServices.Container);
        }
    }
}