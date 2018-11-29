using UnityEngine;
using System.Collections;

public class CollisionBullet : MonoBehaviour
{
    private ZombieMechanism zombieMechanismScript;
    public GameObject bloodParticle;

    // Use this for initialization
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Zombie")
        {
            zombieMechanismScript = col.gameObject.GetComponent<ZombieMechanism>();
            zombieMechanismScript.thisZombieIsBeingShot(Setups.survivor.getSurvivorWeapon().getPower());
            Instantiate(bloodParticle, col.gameObject.transform.position, col.gameObject.transform.rotation);
            Destroy(gameObject);         
        }
        if (col.gameObject.tag == "Decoration" || col.gameObject.tag == "Walls")
        {
            Destroy(gameObject);
        }
    }
        
}