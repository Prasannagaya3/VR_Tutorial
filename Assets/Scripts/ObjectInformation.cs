using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectInformation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _displayObjectName;
    private string defaultText, selectedText;

    private void Start()
    {
        defaultText = "Select any object";
        selectedText = this.gameObject.name;
        SelectedObjectName(false);
    }

    public void SelectedObjectName(bool state)
    {
        if(state)
        {
            _displayObjectName.text = selectedText;
        }
        else
        {
            _displayObjectName.text = defaultText;
        }
    }

}
