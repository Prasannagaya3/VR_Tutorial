using UnityEngine;

public class CollisionWithFire : MonoBehaviour
{
    public GameObject FireBowl;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Bowl") && FireFoam.canDestroy)
        {
            Destroy(FireBowl);
            Destroy(this.gameObject, 2f);
        }
    }
}
