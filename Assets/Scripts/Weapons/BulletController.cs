using UnityEngine;
using System;
using System.Collections;

public class BulletController : MonoBehaviour
{

    public float speed = 5f;

    void Start()
    {
        if (PauseButton.offSFX)
        {
            try
            {
                GetComponent<AudioSource>().Play();
            }
            catch (Exception ex)
            {
                Debug.Log("No Component Attached");
            }
        }
    }

    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, speed * Time.deltaTime, 0);

        pos -= transform.rotation * velocity;

        transform.position = pos;
    }

    public float setSpeed(float B_speed)
    {
        return speed = B_speed;
    }
}