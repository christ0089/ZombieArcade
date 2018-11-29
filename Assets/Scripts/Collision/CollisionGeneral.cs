using UnityEngine;
using System.Collections;

public class CollisionGeneral : MonoBehaviour {
    private ZombieMechanism zombieMechanismScript;

    public int damage = 5;

    void OnTriggerStay2D(Collider2D col) {
        if (col.gameObject.tag == "Survivor") {
            Setups.survivor.Damage(damage);
        }
        if (col.gameObject.tag == "Zombie")
        {
            zombieMechanismScript = col.gameObject.GetComponent<ZombieMechanism>();
            zombieMechanismScript.thisZombieIsBeingShot(damage);
        }
    }
}
