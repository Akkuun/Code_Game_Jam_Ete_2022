using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FireLight : MonoBehaviour
{
    private float baseFloat;
    public float variationFloat = 0;
    // Start is called before the first frame update
    void Start()
    {
        baseFloat = transform.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity;
    }

    // Update is called once per frame
    void Update()
    {
        float variation = baseFloat + Random.Range(-variationFloat, variationFloat);
        transform.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = variation;

    }
}
