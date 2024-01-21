using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 4.0f;
    Rigidbody2D rb;
    private bool isDashing = false;
    private float dashSpeed = 0.5f;
    private float dashAmount = 0.1f;
    public DeathPopUp deathPopUp;
    private bool isCollision = false;
    private Health health;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
        if (health == null)
        {
            Debug.LogError("Health component not found on the enemy GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("player health:");
        Debug.Log(this.health.currHealthChecker());
        if (this.health.currHealthChecker() <= 0)
        {
            Die();
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        transform.rotation = Quaternion.identity;

        if (!isCollision && Input.GetKeyDown(KeyCode.X) && !isDashing)
        {
            StartCoroutine(Dash());
        }
    }
    System.Collections.IEnumerator Dash()
    {
        isDashing = true;

        Vector3 dashDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f).normalized;
        Vector3 dashTarget = transform.position + dashDirection * dashSpeed;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, dashDirection, dashAmount);
        if (hit.collider != null && hit.collider.tag == "Walls")
        {
            dashTarget = hit.point;
        }

        float startTime = Time.time;
        while (Time.time < startTime + dashAmount)
        {
            transform.position = Vector3.MoveTowards(transform.position, dashTarget, (Time.time - startTime) / dashAmount);
            yield return null;
        }
        isDashing = false;
    }

    public void Die()
    {
        Debug.Log("Player Died");
        //deathPopUp.ShowDeathPopup();
        gameObject.SetActive(false);
    }
}
