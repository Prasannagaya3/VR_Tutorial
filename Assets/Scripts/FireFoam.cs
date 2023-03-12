using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class FireFoam : MonoBehaviour
{
    [SerializeField] private InputActionProperty leftClick, rightClick;
    [SerializeField] private GameObject fireFoam;
    [SerializeField] private Transform spawnPoint;
    public static bool canDestroy = false;
    private GameObject spawn;
    private float particleDuration;

    private void Start()
    {
        ObjectInformation currentJug = GetComponent<ObjectInformation>();
        currentJug.activated.AddListener(SpawnFoam);
    }

    private void SpawnFoam(ActivateEventArgs arg)
    {
        spawn = Instantiate(fireFoam);
        particleDuration = spawn.GetComponent<ParticleSystem>().main.duration;
        spawn.transform.SetParent(transform, false);
        spawn.transform.position = spawnPoint.position;

        if (rightClick.action.ReadValue<float>() == 1 || leftClick.action.ReadValue<float>() == 1)
        {
            spawn.GetComponent<ParticleSystem>().Play();
            canDestroy = true;
        }
    }

    public void DestroySpawn(GameObject currentObject)
    {
        Destroy(spawn, particleDuration);
        Destroy(currentObject);
    }
}

//
//Destroy(spawn, particleDuration);
