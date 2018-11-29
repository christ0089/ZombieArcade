using UnityEngine;
using System.Collections;
using System.Collections.Generic; // *** <-- YOU WILL NEED TO ADD THIS TO USE LISTS.

public class NewObjectPoolerScript : MonoBehaviour {

	public static NewObjectPoolerScript current; // A reference to the current "NewObjectPoolerScriptObject.cs".
	public GameObject pooledObject;              // This is the object we are going to pool. 70% Chance of Apprearing
    public GameObject pooledObject_MediumRare;  // This is game object  that has 20% Chance of Appearing;
    public GameObject pooledObject_Boss1;
    public GameObject pooledObject_Boss2;
    public GameObject pooledObject_Boss3; // This is game object  that has 20% Chance of Appearing;
    public int pooledAmount = 5;                // How many objects will there be in the pool.
	public bool willGrow = true;                 // Can the amount of objects in the pool grow?
	public List<GameObject> pooledObjects;       // This is actually the pool.

    int AddNewObjectCounter = 0;

    public float spawnChance;
	
	void Awake()
	{
		current = this; // Assign it to "this" (a way to reference the current Script).
	}


	void Start ()
	{
		pooledObjects = new List<GameObject>();                       // We assign a new List of GameObjects to the "pooledObjects" reference.
		for (int i = 0; i < pooledAmount; i++)                        // Let's build the pool element by element.
		{
            spawnChance = Random.Range(0.0f, 1.0f);
            Debug.Log("SpawnChance:" + spawnChance);
            GameObject obj;
            if (spawnChance <= .70f)
            {
                obj = (GameObject)Instantiate(pooledObject);  // We first instantiate the element to be pooled.
                obj.SetActive(false);                                     // We deactivate it so that it is not showing in the game by default.
                pooledObjects.Add(obj);                                    // Now we push that element to the pool. We are now done.
            }
            else if (spawnChance <= .90 && spawnChance > .70)
            {
                obj = (GameObject)Instantiate(pooledObject_MediumRare);
                obj.SetActive(false);                                     // We deactivate it so that it is not showing in the game by default.
                pooledObjects.Add(obj);                                     // Now we push that element to the pool. We are now done.
            }
            else if (spawnChance <= 1 && spawnChance > .90) {
                float spawnChance2 = Random.Range(0.0f, 1.0f);
                if (spawnChance2 <= .3)
                {
                    obj = (GameObject)Instantiate(pooledObject_Boss1);
                    obj.SetActive(false);                                     // We deactivate it so that it is not showing in the game by default.
                    pooledObjects.Add(obj);                             // Now we push that element to the pool. We are now done.
                }
                else if (spawnChance2 <= .6 && spawnChance2 > .3)
                {
                    obj = (GameObject)Instantiate(pooledObject_Boss2);
                    obj.SetActive(false);                                     // We deactivate it so that it is not showing in the game by default.
                    pooledObjects.Add(obj);                             // Now we push that element to the pool. We are now done.
                }
                else if (spawnChance2 > .6) {
                    obj = (GameObject)Instantiate(pooledObject_Boss3);
                    obj.SetActive(false);                                     // We deactivate it so that it is not showing in the game by default.
                    pooledObjects.Add(obj);
                }
            }

			pooledObjects[i].name="zombie";                        // This is just the name that will appear on the Hierarchy view (doesn't have any effect on the game).
		}
	}
	
	public GameObject GetPooledObject()                               // This method will allow us to get an object from the pool.
	{
        if (AddNewObjectCounter == 5) {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            pooledObjects.Add(obj);
            AddNewObjectCounter = 0;
            return obj;
        }

        int Randomize = Random.Range(0, pooledObjects.Count);           //Gets a random Number from the pool

        if (!pooledObjects[Randomize].activeInHierarchy)                // If the random index is deactivated inside the pool, then retunr that object
        {
            AddNewObjectCounter++;                                      //Add to addCounter to add new Zombie to the pool;
            return pooledObjects[Randomize];
        }
        else {
            for (int i = 0; i < pooledObjects.Count; i++)                 // We go over element by element
            {
                if (!pooledObjects[i].activeInHierarchy)                  // Is there any object deactivated inside the pool?
                {
                    return pooledObjects[i];                              // If so, return that object.
                }
            }
        }

		if (willGrow)                                                 // If this if-condition is reached, that means all objects are active in the game. Shall we create more?
		{
			GameObject obj = (GameObject)Instantiate(pooledObject);
			pooledObjects.Add (obj);
			return obj;
		}
		
		return null;                                                  // If there are no deactivated elements and we don't wish to grow the pool size, then we return a null object.
	}
}
