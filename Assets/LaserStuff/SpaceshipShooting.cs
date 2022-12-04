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
    private Transform[] hardpoints;
    [SerializeField] private Transform HardpointMiddle;
    [SerializeField]
    private LayerMask shootableMask;
    [SerializeField]
    private float hardpointRange = 100f;
    private bool targetInRange = false;

    [Header("=== Laser Settings ===")]
    [SerializeField]
    private LineRenderer[] lasers;
    [SerializeField]
    private ParticleSystem laserHitParticles;
    [SerializeField]
    private float Damage = 1f;
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

    public float CurrentLaserHeat
    {
        get { return currentLaserHeat; }
    }
    public float LaserHeatThreshold
    {
        get { return laserHeatThreshold; }
    }


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
            FireLaser();
        }
        else
        {
            foreach(var laser in lasers)
            {
                laser.gameObject.SetActive(false);
            }

            CoolLaser();
        }
        Debug.Log(currentLaserHeat + " / " + laserHeatThreshold);
    }

    void FireLaser()
    {
        RaycastHit hitInfo;
        if (targetInfo.isTargetInRange(HardpointMiddle.transform.position, HardpointMiddle.transform.forward, out hitInfo, hardpointRange, shootableMask))
        {
            // Make hit particles here.
            foreach (var laser in lasers)
            {
                Vector3 localHitPosition = laser.transform.InverseTransformPoint(hitInfo.point);
                laser.gameObject.SetActive(true);
                laser.SetPosition(1, localHitPosition);
            }
        }
        else
        {
            foreach (var laser in lasers)
            {
                laser.gameObject.SetActive(true);
                laser.SetPosition(1, new Vector3(0, 0, hardpointRange));
            }
        }
        HeatLaser();
    }

    void HeatLaser()
    {
        if (firing && currentLaserHeat < laserHeatThreshold)
        {
            currentLaserHeat += laserHeatRate * Time.deltaTime;

            if (currentLaserHeat >= laserHeatThreshold)
            {
                overHeated = true;
                firing = false;
            }
        }
        
    }
    void CoolLaser()
    {
        if (overHeated)
        {
            if (currentLaserHeat / laserHeatThreshold <= 0.5f)
            {
                overHeated = false;
            }
        }

        if (currentLaserHeat > 0f)
        {
            currentLaserHeat -= laserCoolRate * Time.deltaTime;
        }
    }
    #region Input
    public void onFire(InputAction.CallbackContext context)
    {
        firing = context.performed;
    }
    #endregion
}
