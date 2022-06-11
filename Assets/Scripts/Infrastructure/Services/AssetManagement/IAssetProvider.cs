using UnityEngine;

namespace Infrastructure.Services.AssetManagement {
    public interface IAssetProvider : IService {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector2 at);
        GameObject Instantiate(string path, Vector2 at, Transform parent);
    }
}