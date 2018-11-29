using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform survivorPos;

    public GameObject background;
    private Renderer renderer_BG, renderer_SV;

    private float width_back, h_BG, w_CM, h_CM;
    bool detachInX, detachInY;

	// Use this for initialization
	void Start () {
        renderer_BG = background.GetComponent<Renderer>();

        width_back = renderer_BG.bounds.size.x;
        h_BG = renderer_BG.bounds.size.y;

        h_CM = Camera.main.orthographicSize * 2.0f;
        w_CM = Camera.main.aspect * h_CM;
	}
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(survivorPos.position.x) + (w_CM/2) >= (width_back / 2))
        {
            detachInX = true;
        }
        else {
            detachInX = false;
        }
        if (Mathf.Abs(survivorPos.position.y) + (h_CM/2) >= (h_BG / 2))
        {
            detachInY = true;
        }
        else {
            detachInY = false;
        }

        if (!detachInX && !detachInY) {
            Camera.main.transform.position = new Vector3(survivorPos.position.x, survivorPos.position.y, Camera.main.transform.position.z);
        } else if (!detachInX && detachInY) {
            Camera.main.transform.position = new Vector3(survivorPos.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        } else if (detachInX && !detachInY) {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, survivorPos.position.y, Camera.main.transform.position.z);
        } else if (detachInX && detachInY) {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
        }
    }
}
