using Architecture.StateMachines.States;
using UnityEngine;

namespace Architecture.Bootstrappers {
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner {
        private Game _game;

        private void Awake() {
            _game = new Game(this);
            _game.StateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}