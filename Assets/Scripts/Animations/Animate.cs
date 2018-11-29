using UnityEngine;
using System.Collections;

public class Animate : MonoBehaviour {
    int tempCoinCount;

    Animator anim;

    // Use this for initialization
    void Start () {
        tempCoinCount = 0;
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (tempCoinCount < ScoreManager.coinCoint && ScoreManager.gamestarted == true) {
            anim.SetTrigger("CoinCollected");
            tempCoinCount = ScoreManager.coinCoint;
        }
	}
}
