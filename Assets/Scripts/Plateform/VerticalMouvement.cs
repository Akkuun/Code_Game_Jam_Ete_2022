using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMouvement : MonoBehaviour
{

    public float move_speed = 3f;
    public float minY,maxY;
    bool moving_up = true;
    public bool vertical;




   void Update()
    {
          if(vertical)
          {

            if(transform.position.y>maxY)
            {

            moving_up = false;
            }
            if(transform.position.y < minY)
            {
                moving_up=true;
            }
            if(moving_up)
            {
            transform.position = new Vector2(transform.position.x,transform.position.y +move_speed*Time.deltaTime);
            }
            else transform.position = new Vector2(transform.position.x,transform.position.y -move_speed*Time.deltaTime);
              
           }

    }
}
