using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {
    public Destructible destructible;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Slider healthBarSlider = GetComponent<Slider>();
        healthBarSlider.value = destructible.health / destructible.initialHealth;
    }
}
