using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GunAction : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float travelSpeed = 100f;

    private void Start()
    {
        XRGrabInteractable currentGun = GetComponent<XRGrabInteractable>();
        currentGun.activated.AddListener(FireBullet);
    }

    public void FireBullet(ActivateEventArgs arg)
    {
        GameObject spawn = Instantiate(_bulletPrefab);
        spawn.transform.position = spawnPoint.position;
        spawn.GetComponent<Rigidbody>().velocity = spawnPoint.forward * travelSpeed;
        Destroy(spawn, 5f);
    }
}
