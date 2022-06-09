using UnityEngine;

namespace Architecture.Scripts.Services.Input {
    public class StandaloneInputService : InputService {
        public override Vector2 Axis => DefaultInputAxis();
    }
}