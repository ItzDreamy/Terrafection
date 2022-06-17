using UnityEngine;

namespace Infrastructure.Services.Input {
    public abstract class InputService : IInputService {
        private const string Horizontal = "Horizontal";
        private const string Jump = "Jump";
        public abstract Vector2 Axis { get; }

        protected static Vector2 DefaultInputAxis() {
            return new(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Jump));
        }
    }
}