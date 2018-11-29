using UnityEngine;
using System.Collections;

public class CollissionCoin : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Survivor") {
            Destroy(gameObject);
            if (SaveAndLoad.control.selectedCharacter == 3)
            {
                float chance = Random.Range(0.0f, 1.0f);
                if (chance > .50) {
                    ScoreManager.coinCoint += 2;
                }else {
                    ScoreManager.coinCoint += 1;
                }
            }
            else
            {
                ScoreManager.coinCoint += 1;
            }
        }
    }
}
