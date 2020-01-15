using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxEffect : MonoBehaviour {

    public Transform[] backgrounds;
    public float[] parallaxScales;

    private Transform cam;
    private Vector3 prevCamPos;
    public float smoothing;

    private void Awake()
    {
        cam = Camera.main.transform;
    }

    // Use this for initialization
    void Start () {

        prevCamPos = cam.position;
        parallaxScales = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++) {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < backgrounds.Length; i++) {
            float parallax = (prevCamPos.x - cam.position.x) * parallaxScales[i];
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            Vector3 targetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, targetPos, smoothing * Time.deltaTime);
        }

        prevCamPos = cam.position;
	}
}
