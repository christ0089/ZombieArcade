using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour
{
    public RectTransform transforming;
    int maxW, minW;
    public float duration;

    // Update is called once per frame
    void Update()
    {
        float phi = Time.time / duration * 2 * Mathf.PI;
        float amplitude = Mathf.Cos(phi) * 10.0f;
        transforming.sizeDelta = new Vector2(amplitude,8);
    }
}