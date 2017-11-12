using UnityEngine;
using System.Collections;

public class RotateBarriers : MonoBehaviour {
    public float speed = 1;
    public bool acceleration = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (acceleration)
        {
            transform.Rotate(new Vector3(0, 0, ( ControllBerriers.MaxNbBarriers - ControllBerriers.NbBarriers + 1) * speed * Time.deltaTime));
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
        }
	}
}
