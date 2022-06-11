using Infrastructure.Services;
using Infrastructure.StateMachines;

namespace Infrastructure.Bootstrappers {
    public class Game {
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner) {
            var sceneLoader = new SceneLoader(coroutineRunner);
            StateMachine = new GameStateMachine(sceneLoader, AllServices.Container);
        }
    }
}