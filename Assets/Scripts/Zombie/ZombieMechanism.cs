using UnityEngine;
using System;
using System.Collections;

public class ZombieMechanism : MonoBehaviour {

    private ZombieClass thisZombieClass;
    public Transform survivorTransform;
    public GameObject drop;


    public float ZombieHealthMax = 50.0f;
    public float ZombieHealthMin = 40.0f;

    public float ZombieAttack = 1.0f;

    public float ZombieSpeed = 2f;


    float dropRate = 0.25f; //25% chance of dropping

    // Use this for initialization
    void Start() {
        if (ScoreManager.roundCount == 0)
        {
            thisZombieClass = new ZombieClass(this.gameObject, ZombieAttack, UnityEngine.Random.Range(ZombieHealthMin, ZombieHealthMax), ZombieSpeed);
        }
        else {
            thisZombieClass = new ZombieClass(this.gameObject, ZombieAttack, (UnityEngine.Random.Range(ZombieHealthMin, ZombieHealthMax) + (ScoreManager.roundCount * 1.25f)), ZombieSpeed);
        }
            //Generate random number between 0 and 1
        if (PauseButton.offSFX) {
            try
            {
                GetComponent<AudioSource>().Play();
            }
            catch (Exception   ex) {
                Debug.Log("No Component Attached");
            }
        }
    }

	// Update is called once per frame
	void FixedUpdate () {
        thisZombieClass.moveAndLookAtSurvivor(survivorTransform);
    }
    public ZombieClass getZombieClass() { return thisZombieClass; }


    public void ThisZombieGetsDestroyed() {
        thisZombieClass.getDestroyed();  
    }

    public void thisZombieIsBeingShot(float damage) {
        float  dropChance = UnityEngine.Random.Range(0.0f, 1.0f);;
        if ((thisZombieClass.getZombieHealth()- damage) <= 0)
        {
            
            if (dropChance <= dropRate)
            { 
                Instantiate(drop, this.gameObject.transform.position, Quaternion.identity);
            }

        }
        thisZombieClass.subtractHealth(damage);
    }

    public void thisZombieExploded(float attack) {
        thisZombieClass.setZombeAttackPoints(attack);
    }


}
