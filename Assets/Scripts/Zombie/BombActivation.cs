using UnityEngine;
using System.Collections;

public class BombActivation : MonoBehaviour {

    public Bomb bomb;

    float time; 
    // Use this for initialization

    void OnTriggerStay2D(Collider2D col) {
        if (col.gameObject.tag == "Survivor") {
            time = Time.deltaTime;
            bomb.ActivateExplode(time);
        }
    }
}
