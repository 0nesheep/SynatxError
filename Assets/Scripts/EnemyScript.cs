using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    private float range;
    public Transform player;
    private float distance = 3.0f;
    private bool isCollision = false;
    private float speed = -3.0f;

    private float returnSpeed = 2.0f;
    private float minReturn = 8.0f;
    private Vector2 spawn;



    // Start is called before the first frame update
    void Start()
    {
        spawn = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        range = Vector2.Distance(transform.position, player.position);

        if (range < distance)
        {
            if (!isCollision)
            {
                Vector3 directionToPlayer = transform.position - player.position;
                directionToPlayer.Normalize();

                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            }
        } else if (range > minReturn)
        {
            Invoke("ReturnToSpawn", 5.0f); 
            Vector2 directionToSpawn = spawn - (Vector2)transform.position;
            directionToSpawn.Normalize();
            transform.position = Vector2.MoveTowards(transform.position, spawn, returnSpeed * Time.deltaTime);
        }
        transform.rotation = Quaternion.identity;
    }



}
