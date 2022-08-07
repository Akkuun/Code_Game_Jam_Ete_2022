using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeUwuScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Fire1") > 0)
        {
            /*GameObject bg = GameObject.Find("BackgroundMusic");
            bg.SetActive(true);*/
            gameObject.SetActive(false);
            AudioSource bg = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
            bg.Play();
        }
    }

}
