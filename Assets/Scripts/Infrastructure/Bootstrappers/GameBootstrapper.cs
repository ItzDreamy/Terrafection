using Infrastructure.StateMachines.GameStateMachine.States;
using UnityEngine;

namespace Infrastructure.Bootstrappers {
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner {
        private Game _game;

        private void Awake() {
            _game = new Game(this);
            _game.StateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}