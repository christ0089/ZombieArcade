using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {

    Animator anim;
    public float restartDelay = 5;

    float restartTimer;

    public float health;

    // Use this for initialization
    void Awake () {
        anim = GetComponent<Animator>();    
	}

    // Update is called once per frame
    void Update() {
        if (Setups.survivor.getSurvivorHealth() <= 0 )
        {
            if (SaveAndLoad.control.TopHighScore <= ScoreManager.zombieCount)
            {
                anim.SetTrigger("NewHighScore");
                SaveAndLoad.control.TopHighScore = ScoreManager.zombieCount;
            }
            else {
                anim.SetTrigger("GameOver");
            }
        }
    }

}
