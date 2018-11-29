using UnityEngine;
using System.Collections;

public class LightChange : MonoBehaviour {

    public float duration = 4F;
    public Light lt;
    void Start()
    {
        lt = GetComponent<Light>();
    }
    void Update()
    {
        float phi = Time.time / duration * 2 * Mathf.PI;
        float amplitude = Mathf.Cos(phi) * 0.5F + 0.5F;
        lt.intensity = amplitude * 2;
    }
}
