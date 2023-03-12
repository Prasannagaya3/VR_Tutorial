using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabAttachOnTwoHand : XRGrabInteractable
{
    [SerializeField] private Transform leftAttachPoint, rightAttachPoint;
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if(args.interactorObject.transform.CompareTag("LeftHand"))
        {
            attachTransform = leftAttachPoint;
        }
        else if (args.interactorObject.transform.CompareTag("RightHand"))
        {
            attachTransform = rightAttachPoint;
        }
        base.OnSelectEntered(args);
    }
}
