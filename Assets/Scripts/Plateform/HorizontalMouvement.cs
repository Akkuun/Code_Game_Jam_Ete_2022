using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMouvement : MonoBehaviour
{ 
    public float speed;

    private int direction = 1;
    private Vector3 movement;

    public int x1;
    public int x2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        movement = new Vector3(2 * direction, 0f, 0f);
        transform.position = transform.position + movement * Time.deltaTime * speed;

        if (transform.position.x >= x2)
        {
            direction = -1;
        }

        if (transform.position.x <= x1)
        {
            direction = 1;
        }

    }
    }