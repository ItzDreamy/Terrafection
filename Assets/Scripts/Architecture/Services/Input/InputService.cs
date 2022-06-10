using UnityEngine;

namespace Architecture.Services.Input {
    public abstract class InputService : IInputService {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";
        public abstract Vector2 Axis { get; }

        protected static Vector2 DefaultInputAxis() {
            return new(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));
        }
    }
}