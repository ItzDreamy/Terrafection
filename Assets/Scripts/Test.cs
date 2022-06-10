using Architecture.Services;
using Architecture.Services.Input;
using UnityEngine;

public class Test : MonoBehaviour {
    private IInputService _inputService;

    private void Awake() {
        _inputService = AllServices.Container.Single<IInputService>();
    }

    private void Update() {
        //Debug.Log(_inputService.Axis);
    }
}