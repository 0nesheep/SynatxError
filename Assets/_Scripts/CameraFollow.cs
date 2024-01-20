using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0f, 0f, -10f);
    // Start is called before the first frame update
   
    void Update()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }
}
