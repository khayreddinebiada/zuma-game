using UnityEngine;
using System.Collections;

public class Ring : MonoBehaviour {
    
    public Ring LeftObject;
    public Ring RightObject;
    public GameObject particleSystem;
    public TypeBall.Ball typeRing = TypeBall.Ball.blue;
    public Transform PositionBall;
    public bool IsFilling = false;
    public int NbRing = 0;
    public float waitAndDestroy = 1;
    private Animator Anim;
    private GameObject ObjectBall;
    // Use this for initialization
    void Start()
    {
        Anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        TypeBall ColorBall = coll.gameObject.GetComponent<TypeBall>();
        if (ColorBall)
        {
            if (!IsFilling)
            {
                if (ColorBall.typeBall == typeRing)
                {
                    fPutBall(coll, ColorBall);
                    ObjectBall = coll.gameObject;
                    fFusionBalls();
                }
                else
                {

                }
            }
            else
            {
                Destroy(coll);
            }
        }
    }

    void fPutBall(Collider2D coll, TypeBall ColorBall)
    {
        ColorBall.Delete = false;
        Destroy(coll.gameObject.GetComponent<Rigidbody2D>());
        coll.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        for (int i = 0; i < coll.gameObject.transform.childCount; i++)
            coll.gameObject.transform.GetChild(i).gameObject.SetActive(false);
        coll.transform.position = PositionBall.position;
        coll.transform.rotation = PositionBall.rotation;
        IsFilling = true;
        coll.gameObject.transform.parent = transform;
    }

    void fFusionBalls()
    {
        Ring Right = RightObject;
        Ring Left = LeftObject;
        if ((typeRing != Right.typeRing && typeRing != Left.typeRing) || (gameObject == Left.gameObject && gameObject == Right.gameObject))
        {
            fDelete();
            return;
        }
        else
        {
            int i = 0;
            while (Left.NbRing != NbRing && Left.typeRing == typeRing)
            {
                if (Left.IsFilling)
                {
                    fDelete(Left, false);
                    return;
                }

                Left = Left.LeftObject;
                i++; 
            }
            i = 0;
            while (Right.NbRing != NbRing && Right.typeRing == typeRing)
            {
                if (Right.IsFilling)
                {
                    fDelete(Right, true);
                    return;
                }

                Right = Right.RightObject;
                i++;
            }
        }
    }

    void fDelete()
    {
    //    if (this != this.RightObject && this != this.RightObject)
    //    {
            this.RightObject.LeftObject = this.LeftObject;
            this.LeftObject.RightObject = this.RightObject;
    //    }
        DeleteRing(this);
    }

    void fDelete(Ring R, bool Right)
    {

        print(R.name + "  " + this + "  " + Right);
        Ring ring = R;
        if (Right)
        {
            ControlRings Racine = transform.gameObject.GetComponentInParent<ControlRings>();
            Racine.RacinesRings = this.LeftObject;

            this.LeftObject.RightObject = R.RightObject;
            R.RightObject.LeftObject = this.LeftObject;
            this.LeftObject = null;
            R.RightObject = null;

            while (ring != null)
            {
                Ring r = ring;
                ring = ring.LeftObject;
                DeleteRing(r);
            }
        }
        else
        {
            ControlRings Racine = transform.gameObject.GetComponentInParent<ControlRings>();
            Racine.RacinesRings = this.RightObject;

            this.RightObject.LeftObject = R.LeftObject;
            R.LeftObject.RightObject = this.RightObject;
            this.RightObject = null;
            R.LeftObject = null;

            while (ring != null)
            {
                Ring r = ring;
                ring = ring.RightObject;
                DeleteRing(r);
            }

        }
    }

    void DeleteRing(Ring r)
    {

        StartCoroutine(WaitAndDestroy(waitAndDestroy, r));
    }

    IEnumerator WaitAndDestroy(float wait ,Ring r)
    {
        yield return new WaitForSeconds(wait);
        TypeBall ball = r.gameObject.GetComponentInChildren<TypeBall>();

        r.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        CircleCollider2D circle = r.gameObject.GetComponentInChildren<CircleCollider2D>();
        particleSystem.SetActive(true);
        circle.enabled = false;

        Anim.SetInteger("On", 1);

        if (ball.gameObject)
            Destroy(ball.gameObject);

    }
}
