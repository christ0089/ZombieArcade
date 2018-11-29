using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {


    private ZombieMechanism thisZombieMechanism;
    public GameObject explosiveParticle;

    public float explotion_delay = 1f;
    public float explotion_rate = 1f;
    public float explotion_max_size = 5f;
    public float explotion_force = 1f;
    public float current_radius = 0f;
    public float damage = 10f;

    bool exploded = false;
    CircleCollider2D explotion_radius;
    Animator anim;

    // Use this for initialization
    void Start () {
        explotion_radius = gameObject.GetComponent<CircleCollider2D>();
        thisZombieMechanism =  GetComponent<ZombieMechanism>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
    void FixedUpdate() {
        if (exploded == true) {
            if (current_radius <= explotion_max_size)
            {
                Instantiate(explosiveParticle, this.gameObject.transform.position, this.gameObject.transform.rotation);
                current_radius += explotion_rate;
            }
            else {
                thisZombieMechanism.getZombieClass().getDestroyed();
                exploded = false;
                current_radius = 0;
                explotion_delay = 1f;
            }
            explotion_radius.radius = current_radius;
        }
    }

    public void ActivateExplode(float time)
    {
        explotion_delay -= time;
        anim.SetTrigger("BombActive");
        if (explotion_delay <= 0)
        {
            exploded = true;
            thisZombieMechanism.thisZombieExploded(damage);
         }

    }
}
