using UnityEngine;
using System.Collections;

public class AcidBullet : MonoBehaviour {

    public GameObject bloodParticle;
    // Use this for initialization
    public int damage = 20;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Survivor")
        {
            Setups.survivor.Damage(damage);
            Instantiate(bloodParticle, col.gameObject.transform.position, col.gameObject.transform.rotation);
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Decoration" || col.gameObject.tag == "Walls")   {
            Destroy(gameObject);
        }
    }
}
