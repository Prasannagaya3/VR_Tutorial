using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleportation : MonoBehaviour
{
    [SerializeField] private GameObject leftTeleportation, rightTeleportation;
    [SerializeField] private InputActionProperty _leftTeleportation, _rightTeleportation;
    [SerializeField] private InputActionProperty _leftCancel, _rightCancel;

    private void Update()
    {
        leftTeleportation.SetActive(_leftCancel.action.ReadValue<float>() == 0 && _leftTeleportation.action.ReadValue<float>() > 0.1f);
        rightTeleportation.SetActive(_rightCancel.action.ReadValue<float>() == 0 && _rightTeleportation.action.ReadValue<float>() > 0.1f);
    }
}
