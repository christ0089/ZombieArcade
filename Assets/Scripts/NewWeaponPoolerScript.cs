using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewWeaponPoolerScript : MonoBehaviour
{

    // Use this for initialization
    public static NewWeaponPoolerScript current; // A reference to the current "NewObjectPoolerScriptObject.cs".
    public GameObject pooledObject;              // This is the object we are going to pool. 70% Chance of Apprearing;        // This is game object  that has 20% Chance of Appearing;
    public int pooledAmount = 20;                // How many objects will there be in the pool.
    public bool willGrow = true;                 // Can the amount of objects in the pool grow?
    public List<GameObject> pooledObjects;       // This is actually the pool.

    public float spawnChance;

    void Awake()
    {
        current = this; // Assign it to "this" (a way to reference the current Script).
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();                       // We assign a new List of GameObjects to the "pooledObjects" reference.
        for (int i = 0; i < pooledAmount; i++)                        // Let's build the pool element by element.
        {

            GameObject obj;
            obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);                                     // We deactivate it so that it is not showing in the game by default.
            pooledObjects.Add(obj);
            pooledObjects[i].name = "Weapon";                        // This is just the name that will appear on the Hierarchy view (doesn't have any effect on the game).
        }
    }

    public GameObject GetPooledObject()                               // This method will allow us to get an object from the pool.
    {
        for (int i = 0; i < pooledObjects.Count; i++)                 // We go over element by element
        {

            if (!pooledObjects[i].activeInHierarchy)                  // Is there any object deactivated inside the pool?
            {
                return pooledObjects[i];                              // If so, return that object.
            }
        }
        if (willGrow)                                                 // If this if-condition is reached, that means all objects are active in the game. Shall we create more?
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            pooledObjects.Add(obj);
            return obj;
        }

        return null;
    }
}
