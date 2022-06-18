using StaticData.Generation;
using UnityEngine;

namespace World {
    public class Block : MonoBehaviour {
        public BlockData Data => _data;
        [SerializeField] private BlockData _data;
    }
}