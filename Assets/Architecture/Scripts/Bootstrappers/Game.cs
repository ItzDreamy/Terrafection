using Architecture.Scripts.Services.Input;
using Architecture.Scripts.StateMachines;

namespace Architecture.Scripts.Bootstrappers {
    public class Game {
        public static IInputService InputService;
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner) {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner));
        }
    }
}