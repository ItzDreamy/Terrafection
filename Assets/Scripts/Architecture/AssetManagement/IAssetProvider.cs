using Architecture.Services;
using UnityEngine;

namespace Architecture.AssetManagement {
    public interface IAssetProvider : IService {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector2 at);
    }
}