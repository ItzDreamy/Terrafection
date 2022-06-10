using UnityEngine;

namespace Architecture.Services.Input {
    public interface IInputService : IService {
        Vector2 Axis { get; }
    }
}