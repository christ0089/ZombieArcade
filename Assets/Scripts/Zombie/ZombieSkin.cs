using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZombieSkin : MonoBehaviour {
    public List<Sprite> Sprites = new List<Sprite>();

	// Use this for initialization
	void Awake () {
        float chanceSkin = Random.Range(0.0f, 1.0f);
        

        if (chanceSkin >= .75)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[0];
        }
        else if (chanceSkin >= .50)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[1];
        }
        else if (chanceSkin >= .25)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[2];
        }
        else if (chanceSkin >= 0.0) {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[3];
        }
	}
	
}
