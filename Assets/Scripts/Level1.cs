using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour {
    public GameObject planet;
    public GameObject attackIndicator;
    public float distance;
    private Vector3[] attackVectors = { new Vector3(1, 0, 1), new Vector3(-1, 0, 1), new Vector3(1, 0, -1), new Vector3(-1, 0, -1) };

	// Use this for initialization
	void Start () {
        foreach (Vector3 av in attackVectors) {
            Vector3 pos = planet.transform.position - av * distance;
            Instantiate(attackIndicator, pos, Quaternion.LookRotation(-Vector3.ProjectOnPlane(Vector3.up, av), av));
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
