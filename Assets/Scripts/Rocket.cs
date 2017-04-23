using UnityEngine;
using System.Collections;
using System;

public class Rocket : AbstractBullet {
    private float initialVelocity = 2;
    private float accelForce = 2;
    private float steerForce = 2;
    private Rigidbody rb;
    private Transform target;

    internal override void Target(Vector3 fireDir, Transform enemy) {
        rb = GetComponent<Rigidbody>();
        rb.velocity = fireDir * initialVelocity;
        target = enemy;
    }

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("Expire", 10f, 9999f);
    }

    // Update is called once per frame
    void FixedUpdate() {
        transform.rotation = Quaternion.LookRotation(rb.velocity);
        if (target != null) {
            Vector3 to = (target.position - transform.position).normalized;
            //Debug.Log(Vector3.Angle(to, rb.velocity));
            if (Vector3.Angle(to, rb.velocity) > 5) {
                rb.AddForce(Vector3.ProjectOnPlane(to, rb.velocity).normalized * steerForce);
            }
            rb.AddForce(transform.TransformDirection(Vector3.forward) * accelForce);
        }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other);
        if (other.CompareTag("Enemy")) {

        }
        Destroy(gameObject);
    }
}
