using UnityEngine;
using System.Collections;

public class CollisionAgainstZombies : MonoBehaviour
{
    private ZombieMechanism zombieMechanismScript;
    public Transform damageParticle;

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Zombie")
        {
            zombieMechanismScript = col.gameObject.GetComponent<ZombieMechanism>();
            Setups.survivor.onZombieCollisionPushback(zombieMechanismScript.getZombieClass());
            Instantiate(damageParticle, col.gameObject.transform.position, col.gameObject.transform.rotation);
        }
    }

    // Use this for initialization
}
