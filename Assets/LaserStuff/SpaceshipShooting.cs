using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceshipShooting : MonoBehaviour
{
    [Header("=== Spaceship Settings ===")]
    //[SerializeField] private SpaceshipMovement spaceship;


    [Header("=== Hardpoint Settings ===")]
    [SerializeField]
    private Transform[] hardpoint;
    [SerializeField]
    private LayerMask shootableMask;
    [SerializeField]
    private float hardpointrange = 100f;
    private bool targetInRange = false;

    [Header("=== Laser Settings ===")]
    [SerializeField]
    private LineRenderer[] lasers;
    [SerializeField]
    private ParticleSystem laserHitParticles;
    [SerializeField]
    private float miningPower = 1f;
    [SerializeField]
    private float laserHeatThreshold = 2f;
    [SerializeField]
    private float laserHeatRate = 0.25f;
    [SerializeField]
    private float laserCoolRate = 0.5f;
    private float currentLaserHeat = 0f;
    private bool overHeated = false;

    private bool firing;

    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        HandleLaserFiring();
    }
    private void HandleLaserFiring()
    {
        if (firing && !overHeated)
        {
            fireLaser();
        }
        else
        {
            foreach(var laser in lasers)
            {
                laser.gameObject.SetActive(false);
            }

            coolLaser();
        }
    }

    void fireLaser()
    {
        RaycastHit HitInfo;
        if (targetInfo.isTargetInRange(cam.transform.position, cam.transform.forward, out HitInfo, hardpointrange, shootableMask))
        {
            // Make hit particles here.
            foreach (var laser in lasers)
            {
                Vector3 localHitPosition = laser.transform.InverseTransformPoint(HitInfo.point);
                laser.gameObject.SetActive(true);
                laser.SetPosition(1, localHitPosition);
            }
        }
        else
        {
            foreach (var laser in lasers)
            {
                laser.gameObject.SetActive(true);
                laser.SetPosition(1, new Vector3(0, 0, hardpointrange));
            }
        }
    }


    void coolLaser()
    {
        //Code to cool our laser.
    }
    #region Input
    public void onFire(InputAction.CallbackContext context)
    {
        firing = context.performed;
    }
    #endregion
}
