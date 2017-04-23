using UnityEngine;
using System.Collections;

public class Multishot : AbstractBullet {
    private float velocity = 50;
    private Rigidbody rb;

    public Multishot() {
        damage = 5;
    }

    internal override void Target(Vector3 fireDir, Transform enemy) {
        rb = GetComponent<Rigidbody>();
        Vector3 to = (enemy.position - transform.position).normalized;
        rb.velocity = to * velocity;
    }

    // Use this for initialization
    void Start() {
        Invoke("Expire", 3f);
    }

    // Update is called once per frame
    void FixedUpdate() {
        transform.rotation = Quaternion.LookRotation(rb.velocity);
    }
}
