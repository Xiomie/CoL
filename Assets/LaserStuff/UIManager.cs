using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image laserHeatImage;
    [SerializeField] private SpaceshipShooting spaceshipShooting;

    private void Start()
    {
        spaceshipShooting = FindObjectOfType<SpaceshipShooting>();
    }

    private void Update()
    {
        if (spaceshipShooting != null)
        {
            laserHeatImage.fillAmount = spaceshipShooting.CurrentLaserHeat / spaceshipShooting.LaserHeatThreshold;
        }
    }
}
