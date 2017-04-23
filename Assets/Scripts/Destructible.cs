using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {
    public float health = 100;
    public float initialHealth;

    // Use this for initialization
    void Start() {
        initialHealth = health;
        /*float height;
        if (GetComponent<SphereCollider>() != null) {
            height = GetComponent<SphereCollider>().radius*2;
        } else if (GetComponent<BoxCollider>() != null) {
            height = GetComponent<BoxCollider>().size.y;
        } else if (GetComponent<CapsuleCollider>() != null) {
            height = GetComponent<CapsuleCollider>().height;
        }*/
    }

    // Update is called once per frame
    void Update() {

    }

    public void Damage(GameObject cause, float amount) {
        float oldHealth = health;
        health -= amount;
        if (health <= 0 && oldHealth > 0) {
            health = 0;
            Kill();
        }
    }

    virtual public void Kill() {
        health = 0;
        foreach (TriangleExplosion t in GetComponentsInChildren<TriangleExplosion>()) {
            t.Explode();
        }
        Destroy(gameObject);
    }
}
