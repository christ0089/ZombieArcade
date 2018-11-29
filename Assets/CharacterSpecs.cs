using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSpecs : MonoBehaviour {

    public GameObject[] specs;
    public Sprite[] gamecharacterSkins;

    public Sprite[] specsImg;

    public GameObject gamecharacter;
	// Use this for initialization
	void Start () {
        this.UpdateSpecs();
	}
	
	// Update is called once per frame
    public void UpdateSpecs() {
        switch (SaveAndLoad.control.selectedCharacter) {
            case 0:
                setImg(0);
                setSpecsImg(0);
                break;
            case 1:
                setImg(1);
                setSpecsImg(1);
                break;
            case 2:
                setImg(2);
                setSpecsImg(2);
                break;
            case 3:
                setImg(3);
                setSpecsImg(0);
                break;
            case 4:
                setImg(4);
                setSpecsImg(2);
                break;
            case 5:
                setImg(5);
                setSpecsImg(3);
                break;
            default:
                break;
        }
    }

    private void setImg(int indx) {
        if (this.gameObject.GetComponent<SpriteRenderer>() != null) {
            this.gamecharacter.GetComponent<SpriteRenderer>().sprite = gamecharacterSkins[indx];
        }else {
            if (indx == 0) {
                this.gamecharacter.GetComponent<Image>().enabled = false;
            } else {
                this.gamecharacter.GetComponent<Image>().enabled = true;
                this.gamecharacter.GetComponent<Image>().sprite = gamecharacterSkins[indx];
            }

        }
    }

    private void setSpecsImg(int indx) {
        if (specs.Length != 0) {
            this.specs[0].GetComponent<Image>().sprite = specsImg[indx];
            this.specs[1].GetComponent<Image>().sprite = specsImg[indx];
        }
    }
}
