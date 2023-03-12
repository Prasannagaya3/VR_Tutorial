using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ActivateTeleportation : MonoBehaviour
{
    [SerializeField] private GameObject leftTeleportation, rightTeleportation;
    [SerializeField] private InputActionProperty _leftTeleportation, _rightTeleportation;
    [SerializeField] private InputActionProperty _leftCancel, _rightCancel;
    [SerializeField] private XRRayInteractor leftRay, rightRay;

    private void Update()
    {
        bool leftRayCondition = leftRay.TryGetHitInfo(out Vector3 leftPosition, out Vector3 leftNormal, out int leftPositionInLine, out bool isLeftValidTarget);

        leftTeleportation.SetActive(!leftRayCondition && _leftCancel.action.ReadValue<float>() == 0 && _leftTeleportation.action.ReadValue<float>() > 0.1f);

        bool rightRayCondition = rightRay.TryGetHitInfo(out Vector3 rightPosition, out Vector3 rightNormal, out int rightPositionInLine, out bool isRightValidTarget);

        rightTeleportation.SetActive(!rightRayCondition && _rightCancel.action.ReadValue<float>() == 0 && _rightTeleportation.action.ReadValue<float>() > 0.1f);
    }
}
