using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textAnimation : MonoBehaviour {

    public string prompt;
    Text narration;
    public float visibleTime;
    public float visibleAfter;
    // Use this for initialization
	void Start () {
        narration = GetComponent<Text>();
        narration.text = prompt;
	}
	
	// Update is called once per frame
	void Update () {

        visibleTime -= Time.deltaTime;

        //Debug.Log(visibleTime);

        if (visibleTime <= 0)
        {
            Color currColor = narration.color;
            narration.color = new Color(currColor.r, currColor.g, currColor.b, currColor.a - Time.deltaTime);
            currColor = narration.color;
        }

    }
}
