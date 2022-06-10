using Architecture.Scripts.Services;
using UnityEngine;

namespace Architecture.Scripts.AssetManagement {
    public interface IAssetProvider : IService {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector2 at);
    }
}