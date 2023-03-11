using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    [SerializeField] private Animator _animateHand;
    [SerializeField] private InputActionProperty _pinchActionProperty, _gripActionProperty;

    private void Update()
    {
        float triggerValue = _pinchActionProperty.action.ReadValue<float>();
        _animateHand.SetFloat("Trigger", triggerValue);

        float gripValue = _gripActionProperty.action.ReadValue<float>();
        _animateHand.SetFloat("Grip", gripValue);
    }
}
