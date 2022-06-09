using System.Collections;
using UnityEngine;

namespace Architecture.Scripts.Bootstrappers {
    public interface ICoroutineRunner {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}