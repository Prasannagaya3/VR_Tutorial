using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectGrabWithOffset : XRGrabInteractable
{
    private Vector3 localPosition;
    private Quaternion localRotation;

    private void Start()
    {
        if(!attachTransform)
        {
            GameObject attachPoint = new GameObject("Distance Grab Point");
            attachPoint.transform.SetParent(transform, false);
            attachTransform = attachPoint.transform;
        }
        else
        {
            localPosition = attachTransform.position;
            localRotation = attachTransform.rotation;
        }
    }
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if(args.interactorObject is XRDirectInteractor)
        {
            attachTransform.position = args.interactorObject.transform.position;
            attachTransform.rotation = args.interactorObject.transform.rotation;
        }
        else
        {
            attachTransform.position = localPosition;
            attachTransform.rotation = localRotation;
        }
        base.OnSelectEntered(args);
    }
}
