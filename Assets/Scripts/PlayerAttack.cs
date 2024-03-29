using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;
    private bool attacking = false;
    private float attackTime = 0.15f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Attack();
        }
        if (attacking)
        {
            timer += Time.deltaTime;
            if (timer >= attackTime)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);

            }
        }
        
        
    }
    void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }

    public bool Attacking()
    {
        return attacking;
    }
}
