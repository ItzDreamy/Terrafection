using UnityEngine;

namespace Architecture.Scripts.Services.Input {
    public class MobileInputService : InputService {
        public override Vector2 Axis {
            get {
                var axis = DefaultInputAxis();
                if (axis == Vector2.zero) axis = MobileAxis();
                
                return axis;
            }
        }

        private Vector2 MobileAxis() => new Vector2(0, 0);
    }
}