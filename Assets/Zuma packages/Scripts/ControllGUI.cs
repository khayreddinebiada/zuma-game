using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControllGUI : MonoBehaviour {
    public Animator Skull;
    public float LuanchAnim = 0.15f;
    public GameObject time;
    public float TimeEnd = 60f;
    private Image ImageTime;

	// Use this for initialization
	void Start () {
        ImageTime = time.GetComponent<Image>();
	}
	
	// Update is called once per frame
    void Update()
    {
        int i = Skull.GetInteger("On");
        ImageTime.fillAmount -= (1 / TimeEnd) * Time.deltaTime;
        if (ImageTime.fillAmount < LuanchAnim)
        {
            if (i == 1 | i == 0)
                Skull.SetInteger("On", -1);
        }
        else
        {
            if (i == -1)
                Skull.SetInteger("On", 1);
        }
	}
}
