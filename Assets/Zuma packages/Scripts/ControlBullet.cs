using UnityEngine;
using System.Collections;

public class ControlBullet : MonoBehaviour {

    public GameObject [] Balls;
    public Sprite[] Sprite_Balls;
    public float Speed = 1f;
    public GameObject ChildBullet;

    private SpriteRenderer spriteBall;
    private byte NextObjectIndex = 0;
    private GameObject NextBall;

    // Use this for initialization
    void Start()
    {
        NextObjectIndex = (byte)Random.Range(0, Balls.Length - 0.0001f);
        NextBall = GameObject.Find("Next Ball");
        spriteBall = NextBall.GetComponent<SpriteRenderer>();
        spriteBall.sprite = Sprite_Balls[NextObjectIndex];
	}
	
	// Update is called once per frame
	void Update () {
        Shooting();
	}

    void Shooting()
    {
#if UNITY_EDITOR
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            GameObject oGame = (GameObject)Instantiate(ChildBullet, ChildBullet.transform.position, ChildBullet.transform.rotation);
            CircleCollider2D cCollider = oGame.GetComponent<CircleCollider2D>();
            TypeBall T = oGame.GetComponent<TypeBall>();
            T.enabled = true;
            cCollider.enabled = true;
            Rigidbody2D rigitInst = oGame.GetComponent<Rigidbody2D>();
            Vector2 velocity = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
			float velocityLength = Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position);
            oGame.transform.parent = transform.parent;
            rigitInst.velocity = velocity * Speed / velocityLength;
            GameObject Previous = ChildBullet;
            ChildBullet = (GameObject)Instantiate(Balls[NextObjectIndex], ChildBullet.transform.position, ChildBullet.transform.rotation);
            ChildBullet.transform.parent = Previous.transform.parent;
            NextObjectIndex = (byte)Random.Range(0, Balls.Length - 0.0001f);
            spriteBall.sprite = Sprite_Balls[NextObjectIndex];

            Destroy(Previous);
        }
#elif UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Ended)
                {
                    GameObject oGame = (GameObject)Instantiate(ChildBullet, ChildBullet.transform.position, ChildBullet.transform.rotation);
                    CircleCollider2D cCollider = oGame.GetComponent<CircleCollider2D>();
                    TypeBall T = oGame.GetComponent<TypeBall>();
                    T.enabled = true;
                    cCollider.enabled = true;
                    Rigidbody2D rigitInst = oGame.GetComponent<Rigidbody2D>();
                    Vector2 velocity = Camera.main.ScreenToWorldPoint(touch.position) - transform.position;
                    float velocityLength = Vector2.Distance(Camera.main.ScreenToWorldPoint(touch.position), transform.position);
                    oGame.transform.parent = transform.parent;
                    rigitInst.velocity = velocity * Speed / velocityLength;
                    GameObject Previous = ChildBullet;
                    ChildBullet = (GameObject)Instantiate(Balls[NextObjectIndex], ChildBullet.transform.position, ChildBullet.transform.rotation);
                    ChildBullet.transform.parent = Previous.transform.parent;
                    NextObjectIndex = (byte)Random.Range(0, Balls.Length - 0.0001f);
                    spriteBall.sprite = Sprite_Balls[NextObjectIndex];

                    Destroy(Previous);
                }
            }
        }
#endif
    }
}
