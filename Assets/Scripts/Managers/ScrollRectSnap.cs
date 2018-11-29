using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ScrollRectSnap : MonoBehaviour
{

    public RectTransform panel;
    public Button[] bttn;
    public RectTransform center;
    public static int currentBttn;
    public GameObject shop;

    float[] distance;
    float[] currentPosition;
    private bool dragging = false;
    private int bttnDistance;
    private int minButtonDistance;
    private bool[] selection;
    

    bool changePosition = false;
    static int b = 0;

    // Use this for initialization
    void Start()
    {
        int buttonlength = bttn.Length;
        distance = new float[buttonlength];
        bttnDistance = (int)Mathf.Abs(bttn[1].GetComponent<RectTransform>().anchoredPosition.x - bttn[0].GetComponent<RectTransform>().anchoredPosition.x);
        setId();
    }

    void setId() {
        for (int i = 0; i<bttn.Length; i++){
            if (bttn[i].GetComponents<ButtonManager>() != null)
            {
                try
                {
                    bttn[i].GetComponent<ButtonManager>().setID(i);
                }
                catch {

                }
            }

        }
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < bttn.Length; i++)
        {
            distance[i] = Mathf.Abs(center.transform.position.x - bttn[i].transform.position.x);
        }

        float minDistance = Mathf.Min(distance);


        for (int a = 0; a < bttn.Length; a++)
        {

            if (minDistance == distance[a] && !dragging)
            {
                minButtonDistance = a;
                currentBttn = a;
                if (shop.activeSelf == true && !dragging)
                {
                    if (b != a)
                    {
                        bttn[b].GetComponent<Animator>().SetTrigger("Deselect");
                        b = a;
                        Debug.Log("Active" + b);
                        currentBttn = b;
                        bttn[b].GetComponent<Animator>().SetTrigger("CurrentButton");
                    }
                    if (b == 0 && a == 0 && changePosition == false)
                    {
                        bttn[0].GetComponent<Animator>().SetTrigger("CurrentButton");
                        changePosition = true;
                    }
                }
            }
             
        }

        if (!dragging)
        {
            LerpToBttn(minButtonDistance * -bttnDistance);
        }
    }
    void LerpToBttn(int position)
    {
        float newX = Mathf.Lerp(panel.anchoredPosition.x, position, Time.deltaTime * 10f);
        Vector2 newPosition = new Vector2(newX, panel.anchoredPosition.y);

        panel.anchoredPosition = newPosition;
    }
    public void startDrag()
    {
        dragging = true;
    }
    public void endDrag()
    {
        dragging = false;
    }

    public int getCurrentBttn() {
        return currentBttn;
    }


}
