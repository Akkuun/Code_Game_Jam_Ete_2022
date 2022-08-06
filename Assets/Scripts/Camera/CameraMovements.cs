using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 nextPosition = transform.position;

        nextPosition.x = (float)((int)((player.position.x+18)/36)*36);
        transform.position = nextPosition;
    }
}
