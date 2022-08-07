using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesRespawn : MonoBehaviour
{

    public GameObject m_obstacles;

    public void Respawn()
    {
        GameObject ChildGameObject = gameObject.transform.GetChild(0).gameObject;
        Destroy(ChildGameObject);
        Transform t = transform;
        //t.position += new Vector3(2.472534f, -4.589549f, 9.844358f);
        GameObject bullet = Instantiate(m_obstacles, t);
    }

}
