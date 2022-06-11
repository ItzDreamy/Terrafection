using UnityEngine;

namespace Infrastructure.Services.Input {
    public class StandaloneInputService : InputService {
        public override Vector2 Axis => DefaultInputAxis();
    }
}