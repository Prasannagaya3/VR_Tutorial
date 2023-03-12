using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectInformation : XRGrabInteractable
{
    [SerializeField] private Transform leftAttachPoint, rightAttachPoint;
    [SerializeField] private string displayInfo;
    public ObjectDisplay ObjectDisplayInfo;

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        ObjectDisplayInfo.DisplayObjectName.text = displayInfo;
        base.OnHoverEntered(args);
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        ObjectDisplayInfo.DisplayObjectName.text = ObjectDisplayInfo.DisplayObjectReset;
        base.OnHoverExited(args);
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("LeftHand"))
        {
            attachTransform = leftAttachPoint;
        }
        if (args.interactorObject.transform.CompareTag("RightHand"))
        {
            attachTransform = rightAttachPoint;
        }
        base.OnSelectEntered(args);
    }
}
