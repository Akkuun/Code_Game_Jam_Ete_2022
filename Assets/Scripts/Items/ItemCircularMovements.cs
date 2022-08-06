using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCircularMovements : MonoBehaviour
{
    private Transform m_rotationCenter;

    private float m_posX;
    private float m_posY;
    private float m_angle = 0;

    //-------------------------------

    public float m_angularSpeed = 2f;
    public float m_rotationRadius = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_rotationCenter = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = m_rotationCenter.position;

        m_posX = m_rotationCenter.position.x + Mathf.Cos(m_angle) * m_rotationRadius;
        m_posY = m_rotationCenter.position.y + Mathf.Sin(m_angle) * m_rotationRadius;

        transform.position = new Vector2(m_posX, m_posY);
        m_angle += Time.deltaTime * m_angularSpeed;

        if (m_angle>= 360)
        {
            m_angle = 0;
        }
    }
}
