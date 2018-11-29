using UnityEngine;
using System.Collections;

public class GetWeaponFromPool : MonoBehaviour
{

	public float timeToFirstZombie = 1.0f;  // Time for the first zombie to appear.
    public float timeToNextZombie = 4.0f;  // Time for the next zombies to appear.

    void Start()
    {
        // With this line we are calling the "SpawnNewZombie" function after "timeToFirstZombie" seconds and every "timeToNextZombie" seconds.
        InvokeRepeating("SpawnNewZombie", timeToFirstZombie, timeToNextZombie);
    }

    void SpawnNewZombie()
    {
        GameObject obj = NewWeaponPoolerScript.current.GetPooledObject(); // We get an object (zombie) from the pool.

        if (obj == null) return;                                             // If "null" was returned, then we exit the function.

        obj.transform.position = new Vector3(randomXOffset(),
                                              randomYOffset(),
                                                    ZOffset());          // If "null" was not returned, then we re-position the new zombie.

        obj.SetActive(true);                                              // And we finally activate it.
    }


    float randomXOffset()
    {            // Function to generate a random number for the X position of the Zombie.
        return Random.Range(-15, 15);
    }
    float randomYOffset()
    {            // Function to generate a random number for the Y position of the Zombie.
        return Random.Range(-5, 5);
    }
    float ZOffset()
    {                  // Function to retrieve the first-ever object's z-position.
        return NewWeaponPoolerScript.current.pooledObject.transform.position.z;
    }
}
