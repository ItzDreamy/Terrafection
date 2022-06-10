using UnityEngine;

namespace Architecture.Services.Input {
    public class MobileInputService : InputService {
        public override Vector2 Axis {
            get {
                var axis = DefaultInputAxis();
                if (axis == Vector2.zero) axis = MobileAxis();

                return axis;
            }
        }

        private Vector2 MobileAxis() {
            return new(0, 0);
        }
    }
}