using UnityEngine;
using System.Collections;

public class BazookaBullet : MonoBehaviour {
    private ZombieMechanism thisZombieMechanism;
    private BulletController thisBulletController;
    public GameObject explosiveParticle;
    public GameObject bloodParticle;
    private Rigidbody2D thisRigidBody;

    public float explotion_delay = 2f;
    public float explotion_rate = 1f;
    public float explotion_max_size = 5f;
    public float explotion_force = 1f;
    public float current_radius = 0f;
    public float damage = 30f;
    bool exploded = false;
    int i = 0 ;
    public bool disableInstantBlow;
    CircleCollider2D explotion_radius;

    // Use this for initialization
    void Start()
    {
        explotion_radius = gameObject.GetComponent<CircleCollider2D>();
        thisBulletController = gameObject.GetComponent<BulletController>();
        thisRigidBody = gameObject.GetComponent<Rigidbody2D>();
        damage = 0;
     }
    public void ActivateExplode()
    {
        explotion_delay -= Time.deltaTime;
        if (explotion_delay <= 0)
        {
            exploded = true;
            damage = 30;
        }

    }
    public void Explode()
    {
        if (exploded == true)
        {
            FreezePosition();
            if (current_radius <= explotion_max_size)
            {
                if (i <= 3)
                {
                    Instantiate(explosiveParticle, this.gameObject.transform.position, this.gameObject.transform.rotation);
                    i++;
                }
                current_radius += explotion_rate;
            }
            else {
                Destroy(gameObject);
                exploded = false;
                current_radius = 0;
            }
            explotion_radius.radius = current_radius;
        }
    }

    void FreezePosition()
    {
        thisRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (disableInstantBlow == true)
        {
            ActivateExplode();
            FreezePosition();
        }
        Explode();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Zombie")
        {
            thisZombieMechanism = col.gameObject.GetComponent<ZombieMechanism>();
            if (disableInstantBlow == false)
            {
                exploded = true;
                damage = 30;
            } else {
                ActivateExplode();
                FreezePosition();
            }
            thisZombieMechanism.thisZombieIsBeingShot(damage);
            Instantiate(bloodParticle, col.gameObject.transform.position, col.gameObject.transform.rotation);
        }
        if (col.gameObject.tag == "Decoration" || col.gameObject.tag == "Walls") 
        {
            if (disableInstantBlow == false)
            {
                exploded = true;                
                damage = 30;
            } else {
                FreezePosition();
            }

        }
    }
   

}