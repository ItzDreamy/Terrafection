using UnityEngine;

namespace Architecture.StateMachines.States {
    public class WorldGenerationState : IState {
        private readonly GameStateMachine _stateMachine;

        public WorldGenerationState(GameStateMachine stateMachine) {
            _stateMachine = stateMachine;
        }
        public void Enter() {
            Debug.Log("World generation...");
            _stateMachine.Enter<LoadProgressState>();
        }

        public void Exit() {
            
        }
    }
}