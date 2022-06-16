using UnityEngine;

namespace StaticData.Generation {
    [CreateAssetMenu(fileName = "BlockData", menuName = "StaticData/Generation/Block")]
    public class BlockData : ScriptableObject {
        public BlockTypeId BlockTypeId;
        public GameObject BlockPrefab;
    }
}