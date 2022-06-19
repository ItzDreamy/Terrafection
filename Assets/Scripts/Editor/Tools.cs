using UnityEditor;
using UnityEngine;

namespace Editor {
    public static class Tools {
        [MenuItem("Tools/ClearPlayerPrefs")]
        public static void ClearPrefs() =>
            PlayerPrefs.DeleteAll();
    }
}