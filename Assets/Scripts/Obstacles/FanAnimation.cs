using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanAnimation : MonoBehaviour
{

    public bool toTheRight, toTheLeft;
    public bool down, up;

    void FixedUpdate()
    {
        if (gameObject.GetComponents<Animator>() != null)
        {
            if (toTheLeft) GetComponent<Animator>().SetBool("Expulsion", false);
            if (toTheRight) GetComponent<Animator>().SetBool("Expulsion", true);
            if (down) GetComponent<Animator>().SetBool("Expulsion", true);
            if (up) GetComponent<Animator>().SetBool("Expulsion", false);
        }

    }
}
