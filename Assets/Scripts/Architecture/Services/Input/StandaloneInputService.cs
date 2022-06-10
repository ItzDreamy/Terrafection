using UnityEngine;

namespace Architecture.Services.Input {
    public class StandaloneInputService : InputService {
        public override Vector2 Axis => DefaultInputAxis();
    }
}