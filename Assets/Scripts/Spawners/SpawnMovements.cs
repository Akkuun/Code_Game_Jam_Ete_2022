using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMovements : MonoBehaviour
{
    public float speed = 0.5f;

    private int direction = 1;
    private Vector3 movement;

    public float xmin, xmax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        movement = new Vector3(2 * direction, 0f, 0f);
        transform.position = transform.position + movement * Time.deltaTime * speed;

        if (transform.position.x >= xmax)
        {
            direction = -1;
        }

        if (transform.position.x <= xmin)
        {
            direction = 1;
        }

    }

    void FixedUpdate()
    {

    }

}
