using UnityEngine;
using System.Collections;

public class ControlGun : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        ControlMouse();
	}

    void ControlMouse()
    {
        Vector2 CameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 V = new Vector2(CameraPosition.x - transform.position.x, CameraPosition.y - transform.position.y);
        Quaternion Q = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(V), 1);
        Vector3 Rotate = Q.eulerAngles;
        if (CameraPosition.x > 0)
            transform.eulerAngles = new Vector3(0, 0,(270 - Rotate.x));
        else
            transform.eulerAngles = new Vector3(0, 0,(90 + Rotate.x));
    }
}
