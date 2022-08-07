using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class CameraMovements : MonoBehaviour
{
    private Transform player;

    private float m_speed = 24f;

    private GameObject[] m_obstacles;

    private bool m_hasReset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        m_obstacles = GameObject.FindGameObjectsWithTag("ObstacleRespawn");
        m_hasReset = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 nextPosition = transform.position;
        float cameraFuturPosition = (float)((int)((player.position.x + 15) / 30) * 30);
        if (cameraFuturPosition != Mathf.Round(transform.position.x))
        {
            if(m_hasReset)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<ItemCollector>().ResetItem();
                m_hasReset = false;

            }
            if (cameraFuturPosition > transform.position.x)
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
            if(!m_hasReset)
            {
                m_hasReset = true;
                GameObject currentObstacle = GameObject.FindGameObjectWithTag("ObstacleRespawn");
                if (currentObstacle != null)
                {
                    currentObstacle.GetComponent<ObstaclesRespawn>().Respawn();
                }
            }
            
        }
    }
}
