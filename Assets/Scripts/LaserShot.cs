using UnityEngine;
using System.Collections;
using System;

public class LaserShot : AbstractBullet {
    private float velocity = 20;
    private Rigidbody rb;

    public LaserShot() {
        damage = 20;
    }

    internal override void Target(Vector3 fireDir, Transform enemy) {
        rb = GetComponent<Rigidbody>();
        Vector3 to = (enemy.position - transform.position).normalized;
        rb.velocity = to * velocity;
    }

    // Use this for initialization
    void Start() {
        Invoke("Expire", 10f);
    }

    // Update is called once per frame
    void FixedUpdate() {
        transform.rotation = Quaternion.LookRotation(rb.velocity);
    }
}
