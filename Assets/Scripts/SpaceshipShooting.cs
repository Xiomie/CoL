using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipShooting : MonoBehaviour
{
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
}
