using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Destructible))]
public class ImpactDamage : MonoBehaviour {
    public float damage = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision) {
        Destructible other = collision.gameObject.GetComponent<Destructible>();
        if (other != null) {
            other.Damage(gameObject, damage);
            Destructible me = GetComponent<Destructible>();
            me.Kill();
        }
    }
}
