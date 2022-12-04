using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    // Bullet
    public GameObject bullet;

    // Bullet Force
    public float shootForce, upwardForce;

    // Gun Stats
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;

}
