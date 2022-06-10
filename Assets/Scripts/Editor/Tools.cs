using UnityEditor;
using UnityEngine;

namespace Editor {
    public class Tools {
        [MenuItem("Tools/ClearPlayerPrefs")]
        public static void ClearPrefs() {
            PlayerPrefs.DeleteAll();
        }
    }
}