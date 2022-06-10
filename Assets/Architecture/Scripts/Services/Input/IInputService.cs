using UnityEngine;

namespace Architecture.Scripts.Services.Input {
    public interface IInputService : IService {
        Vector2 Axis { get; }
    }
}