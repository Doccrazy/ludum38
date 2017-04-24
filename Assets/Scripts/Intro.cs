using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour {
    public SlowRotate planetRotate;
    public LevelProgression firstLevel;
    public Camera outsideCamera;
    public Camera playerCamera;

	// Use this for initialization
	void Start () {
        Invoke("StartIntro", 0.2f);
    }

    void StartIntro() {
        outsideCamera.enabled = true;
        playerCamera.enabled = false;
        planetRotate.enabled = true;
        Invoke("EndIntro", 10);
    }

    void EndIntro() {
        outsideCamera.enabled = false;
        playerCamera.enabled = true;
        planetRotate.enabled = false;
        firstLevel.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
