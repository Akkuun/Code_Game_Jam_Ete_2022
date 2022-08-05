using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    private float m_movementSpeed = 8f;
    private float m_direction = -1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position.x += m_direction * m_movementSpeed * Time.deltaTime;
        transform.position = position;
    }

    public void ChangeDirection()
    {
        m_direction = 1f;
    }
}
