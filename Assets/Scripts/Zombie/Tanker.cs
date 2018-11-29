using UnityEngine;
using System.Collections;

public class Tanker : MonoBehaviour {

    private ZombieMechanism thisZombieScript;

    public float max_Speed = 5;
    public float berserTime = 1;
    public float lockTime = 1;
    public float normalSpeed = 0.5f;
    // Use this for initialization

    void Start() {
        thisZombieScript = this.gameObject.GetComponent<ZombieMechanism>();
    }

	// Update is called once per frame
	void Update () {
        lockTime -= Time.deltaTime;
        
        if (lockTime <= 0)
        {
            berserTime -= Time.deltaTime;
            if (berserTime > 0)
            {
                this.gameObject.GetComponent<Rigidbody2D>().mass = 1500;
                thisZombieScript.getZombieClass().setZombieSpeed(max_Speed);
                this.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
            }
            else {
                lockTime = 1;
                berserTime = 1;
            }
        }
        else {
            thisZombieScript.getZombieClass().setZombieSpeed(normalSpeed);
            gameObject.GetComponent<Rigidbody2D>().mass = 1000;
            gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;

        }
	}
}
