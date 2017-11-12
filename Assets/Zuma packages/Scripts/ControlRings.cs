using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlRings : MonoBehaviour
{
    public Ring RacinesRings;
    public Ring[] Rings;
	// Use this for initialization
	void Awake () {
        PutRacines();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void PutRacines()
    {
        Rings = GetComponentsInChildren<Ring>();
        RacinesRings = Rings[0];
        Rings[0].LeftObject = Rings[Rings.Length - 1];
        Rings[Rings.Length - 1].RightObject = Rings[0];
        Rings[0].NbRing = 0;
        for (int i = 1; i < Rings.Length; i++)
        {
            Rings[i].NbRing = i;
             Rings[i].LeftObject = Rings[i - 1];
             Rings[i - 1].RightObject = Rings[i];
        }
    }
}

