using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class SelectedWeapon : MonoBehaviour {

    public List<Sprite> Sprites = new List<Sprite>();
    int selectNumber = 0;

    void Start() {
       
       SelectWeapon(selectNumber);
    }

    // Use this for initialization

    public void SelectWeapon( int number) {
        if (number == 0)
        {
            this.gameObject.GetComponent<Image>().sprite = Sprites[0];
        }
        else if (number == 1)
        {
            this.gameObject.GetComponent<Image>().sprite = Sprites[1];
        }
        else if (number == 2)
        {
            this.gameObject.GetComponent<Image>().sprite = Sprites[2];
        }
        else if (number == 3)
        {
            this.gameObject.GetComponent<Image>().sprite = Sprites[3];

        }
        else if (number == 4)
        {
            this.gameObject.GetComponent<Image>().sprite = Sprites[4];
        }
        else if (number == 5)
        {
            this.gameObject.GetComponent<Image>().sprite = Sprites[5];
        }
   
    }
	
	// Update is called once per frame


}

