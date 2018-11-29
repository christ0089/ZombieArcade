using UnityEngine;
using System.Collections;

public class CollisionAgianstAllZombies : MonoBehaviour
{
    private ZombieMechanism zombieMechanismScript;
    public GameObject deathParticle;
    // Use this for initialization
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Zombie")
        {
            zombieMechanismScript = col.gameObject.GetComponent<ZombieMechanism>();
            zombieMechanismScript.ThisZombieGetsDestroyed();
            Instantiate(deathParticle, col.gameObject.transform.position, col.gameObject.transform.rotation);
        }
    }
}

