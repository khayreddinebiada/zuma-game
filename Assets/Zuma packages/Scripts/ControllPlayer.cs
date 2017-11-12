using UnityEngine;
using System.Collections;

public class ControllPlayer : MonoBehaviour {
    public static float time = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
	}

    public static void GameOver()
    {
        print("Game Over");
    } 
}
