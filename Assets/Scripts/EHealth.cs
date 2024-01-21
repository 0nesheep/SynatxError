using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHealth : MonoBehaviour
{
    [SerializeField]
    private int currhealth = 50;
    private int maxHealth = 50;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(int damage)
    {
        currhealth -= damage;
        if (currhealth <= 0)
        {
            Debug.Log("health no more");
        }
    }

    public int currHealthChecker()
    {
        return currhealth;
    }

    public int maxHealthChecker()
    {
        return maxHealth;
    }


}
