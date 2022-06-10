using System.Collections;
using UnityEngine;

namespace Architecture.Bootstrappers {
    public interface ICoroutineRunner {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}