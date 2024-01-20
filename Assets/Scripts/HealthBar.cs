using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Health healthComponent; // Reference to the Health script on the player or enemy
    public Image healthBarImage;

    void Start()
    {
        if (healthBarImage == null)
        {
            Debug.LogError("Health Bar Image component not assigned.");
        }

        if (healthComponent == null)
        {
            Debug.LogError("Health Component not assigned.");
        }
    }

    void Update()
    {
        // Update the health bar size based on the current health
        UpdateHealthBar();

        // Move the health bar to follow the player or enemy
        FollowTarget();
    }

    void UpdateHealthBar()
    {
        float fillAmount = (float)healthComponent.currHealthChecker() / healthComponent.maxHealthChecker();
        healthBarImage.fillAmount = fillAmount;
    }

    void FollowTarget()
    {
        if (healthComponent != null)
        {
            // Set the health bar's position to be above the player or enemy
            Vector3 targetPosition = healthComponent.transform.position;
            targetPosition.y += 0.5f; 
            transform.position = targetPosition;
        }
    }
}
