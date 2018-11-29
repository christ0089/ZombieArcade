using UnityEngine;
using System.Collections;

public class GetZombieFromPool : MonoBehaviour

{
	public float timeToFirstZombie = 1.0f;  // Time for the first zombie to appear.
	public float timeToNextZombie  = 4.0f;  // Time for the next zombies to appear.

    public static GetZombieFromPool ZombieNumber;
    public static bool endRound;

    public int ZombiesPerRound;
    int count = 0;

	void Start ()
	{
        
        // With this line we are calling the "SpawnNewZombie" function after "timeToFirstZombie" seconds and every "timeToNextZombie" seconds.
		InvokeRepeating ("SpawnNewZombie", timeToFirstZombie, timeToNextZombie);
	}
	
	void SpawnNewZombie() {

        if (count < ZombiesPerRound && Setups.survivor.getSurvivorHealth() > 0)
        {
            GameObject obj = NewObjectPoolerScript.current.GetPooledObject(); // We get an object (zombie) from the pool.

            endRound = false;
            if (obj == null) return;                                             // If "null" was returned, then we exit the function.

            obj.transform.position = new Vector3(randomXOffset(),
                                                  randomYOffset(),
                                                        ZOffset());          // If "null" was not returned, then we re-position the new zombie.

            obj.SetActive(true);                                            // And we finally activate it.
            if (obj.activeSelf == true) {
                count++;
                Debug.Log(count + " vs." + ZombiesPerRound );
            }
        }
        if (count == ZombiesPerRound) {
            endRound = true;
            count = 0;
            ZombiesPerRound = (int)(ZombiesPerRound * 1.50f);  
        }
	}
	
	
	float randomXOffset() {            // Function to generate a random number for the X position of the Zombie.
		return Random.Range (-15, 15);
	}
	float randomYOffset() {            // Function to generate a random number for the Y position of the Zombie.
		return Random.Range (-5,5);
	}
	float ZOffset() {                  // Function to retrieve the first-ever object's z-position.
		return NewObjectPoolerScript.current.pooledObject.transform.position.z;
	}
}
