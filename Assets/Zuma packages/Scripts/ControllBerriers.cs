using UnityEngine;
using System.Collections;

public class ControllBerriers : MonoBehaviour {
    public bool Istouched = false;

    public static int NbBarriers = 0;
    public static int MaxNbBarriers = 0;
    private Animator anim;
    
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        NbBarriers++;
        MaxNbBarriers = NbBarriers;
	}
	
	// Update is called once per frame
	void Update () {
        if (Istouched)
        {
            NbBarriers--;
            if (NbBarriers == 0)
            {
                ControllPlayer.GameOver();
            }
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.transform.gameObject.layer == 9)
        {
            anim.SetInteger("On", 1);
            Destroy(coll.gameObject);
        }
    }
}
