using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuntimeMaterial : MonoBehaviour
{
    [SerializeField]
    private Transform player, _materialObject;
    [SerializeField]
    private Material _highlightedMaterial;
    [SerializeField]
    private Image _fadeEffect;

    Material defaultMaterial;

    private void Update()
    {
        if(_materialObject)
        {
            Renderer currentObject = _materialObject.GetComponent<Renderer>();
            currentObject.material = defaultMaterial;

            defaultMaterial = null;
            _materialObject = null;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                Renderer currentObject = hit.transform.GetComponent<Renderer>();
                defaultMaterial = currentObject.material;
                currentObject.material = _highlightedMaterial;

                if (Input.GetMouseButtonDown(0))
                {
                    player.position = new Vector3(hit.transform.position.x, hit.transform.position.y + 0.5f, hit.transform.position.z);
                    player.rotation = hit.transform.rotation;
                }
                _materialObject = hit.transform;
            }

            if (hit.collider.CompareTag("Background"))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 mousePoint = hit.point;
                    player.position = new Vector3(mousePoint.x, mousePoint.y + 1f, mousePoint.z);
                }
            }
        }
    }

    IEnumerator ScreenFade()
    {
        for (int i = 0; i < 128; i++)
        {
            _fadeEffect.color = new Color32(100, 100, 100, (byte)(i * 2));
            yield return new WaitForSeconds(0.01f);
        }
        for (int i = 127; i >= 0; i--)
        {
            _fadeEffect.color = new Color32(100, 100, 100, (byte)(i * 2));
            yield return new WaitForSeconds(0.01f);
        }
    }
}
