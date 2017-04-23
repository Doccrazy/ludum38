using UnityEngine;
using System.Collections;
using System;

public class LaserShot : AbstractBullet {
    private Rigidbody rb;

    public LaserShot() {
        damage = Constants.LASER_DMG;
    }

    internal override void Target(Vector3 fireDir, Transform enemy) {
        rb = GetComponent<Rigidbody>();
        Vector3 to = (enemy.position - transform.position).normalized;
        rb.velocity = to * Constants.LASER_VELOCITY;
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
