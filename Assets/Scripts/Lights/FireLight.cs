using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FireLight : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float variation = 0.4f + Random.Range(-0.01f, 0.01f);
        transform.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = variation;

    }
}
