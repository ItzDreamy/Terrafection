using Architecture.Scripts.StateMachines;
using Architecture.Scripts.StateMachines.States;
using UnityEngine;

namespace Architecture.Scripts.Bootstrappers {
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner {
        private Game _game;

        private void Awake() {
            _game = new Game(this);
            _game.StateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}