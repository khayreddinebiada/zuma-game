using UnityEngine;
using System.Collections;

public class TypeBall : MonoBehaviour {
    public float TimeAndDestroy = 4;
    public enum Ball { red, blue, yellow, pink, Green, Orange};
    public Ball typeBall = Ball.pink;
    public bool Delete = true;
	// Use this for initialization
	void Start () {
        StartCoroutine(WaitAndDestroyObject(TimeAndDestroy));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public 
    IEnumerator WaitAndDestroyObject(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (Delete) Destroy(gameObject);
    }
}
