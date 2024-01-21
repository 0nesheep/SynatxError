using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 7;
    private PlayerAttack playerAttack;

    void Start()
    {
        // Find the PlayerAttack script on the same GameObject or its parent
        playerAttack = GetComponentInParent<PlayerAttack>();
        if (playerAttack == null)
        {
            Debug.LogError("PlayerAttack script not found.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Health>() != null && playerAttack != null && playerAttack.Attacking())
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
        }
    }
    public void Attack(Health targetHealth)
    {
        if (targetHealth != null)
        {
            targetHealth.Damage(damage);
        }
    }
}
