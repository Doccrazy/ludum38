using UnityEngine;
using System.Collections;
using System;

public class LaserShot : AbstractBullet {
    private float velocity = 10;
    private Rigidbody rb;

    internal override void Target(Vector3 fireDir, Transform enemy) {
        rb = GetComponent<Rigidbody>();
        Vector3 to = (enemy.position - transform.position).normalized;
        rb.velocity = to * velocity;
    }

    // Use this for initialization
    void Start() {
        InvokeRepeating("Expire", 10f, 9999f);
    }

    // Update is called once per frame
    void FixedUpdate() {
        transform.rotation = Quaternion.LookRotation(rb.velocity);
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other);
        if (other.CompareTag("Enemy")) {

        }
        Destroy(gameObject);
    }
}
