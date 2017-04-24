using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHider : MonoBehaviour {
    public GameObject mainUI;
    public GameObject externalUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        mainUI.SetActive(Camera.main != null);
        externalUI.SetActive(Camera.main == null);
    }
}
