using UnityEngine;
using TMPro;

public class ObjectDisplay : MonoBehaviour
{
    public TextMeshProUGUI DisplayObjectName;
    [HideInInspector]
    public string DisplayObjectReset;

    private void Start()
    {
        DisplayObjectReset = "Select any Jug";
        DisplayObjectName.text = DisplayObjectReset;
    }
}
