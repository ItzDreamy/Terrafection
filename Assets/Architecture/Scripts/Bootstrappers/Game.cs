using Architecture.Scripts.Services.Input;
using UnityEngine.Device;

namespace Architecture.Scripts.Bootstrappers {
    public class Game {
        public static IInputService InputService;
        
        public Game() {
            RegisterInputService();
        }

        private static void RegisterInputService() {
            if (Application.isMobilePlatform) {
                InputService = new MobileInputService();
            }
            else {
                InputService = new StandaloneInputService();
            }
        }
    }
}