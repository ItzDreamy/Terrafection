using System.Collections;
using UnityEngine;

namespace Infrastructure.Bootstrappers {
    public interface ICoroutineRunner {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}