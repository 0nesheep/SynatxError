using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class RunEnemy : MonoBehaviour
{
    [SerializeField] public Transform player;
    private float range;
    private float distance = 5.0f;
    private bool isCollision = false;
    private float speed = 2.5f;

    private float returnSpeed = 2.0f;
    private float minReturn = 8.0f;
    private Vector2 spawn;
    private Health health;

    // Start is called before the first frame update
    void Start()
    {
        spawn = transform.position;
        health = GetComponent<Health>();
        if (health == null)
        {
            Debug.LogError("Health component not found on the enemy GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(health.currHealthChecker());
        if (health.currHealthChecker() <= 0)
        {
            Die();
            return;
        }
        range = Vector2.Distance(transform.position, player.position);

        if (range < distance)
        {
            if (!isCollision)
            {

                transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            }
        }
        else if (range > minReturn)
        {
            Invoke("ReturnToSpawn", 5.0f);
            Vector2 directionToSpawn = spawn - (Vector2)transform.position;
            directionToSpawn.Normalize();
            transform.position = Vector2.MoveTowards(transform.position, spawn, returnSpeed * Time.deltaTime);
        }
        transform.rotation = Quaternion.identity;
    }

    public void Die()
    {
        Debug.Log("Enemy Died");
        gameObject.SetActive(false);
    }


}
