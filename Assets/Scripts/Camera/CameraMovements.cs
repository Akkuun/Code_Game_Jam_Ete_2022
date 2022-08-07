using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    private Transform player;

    private float m_speed = 24f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 nextPosition = transform.position;
        float cameraFuturPosition = (float)((int)((player.position.x + 15) / 30) * 30);
        if (cameraFuturPosition != Mathf.Round(transform.position.x))
        {
            if(cameraFuturPosition > transform.position.x)
            {
                nextPosition.x += Time.deltaTime * m_speed;
                transform.position = nextPosition;
            }
            else
            {
                nextPosition.x -= Time.deltaTime * m_speed;
                transform.position = nextPosition;
            }
        }
        else
        {
            nextPosition.x = cameraFuturPosition;
            transform.position = nextPosition;
        }
    }
}
