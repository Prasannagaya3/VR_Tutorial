using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    [SerializeField] private InputActionProperty _pinchActionProperty;
    [SerializeField] private InputActionProperty _gripActionProperty;

    [SerializeField] private Animator _animateHand;

    private void Update()
    {
        float triggerValue = _pinchActionProperty.action.ReadValue<float>();
        _animateHand.SetFloat("Trigger", triggerValue);

        float gripValue = _gripActionProperty.action.ReadValue<float>();
        _animateHand.SetFloat("Grip", gripValue);
    }
}
