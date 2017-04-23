using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour {

    public float speed = 10.0f;
    public float gravity = 10.0f;
    public float maxVelocityChange = 10.0f;
    public bool canJump = true;
    public float jumpHeight = 2.0f;
    private bool grounded = false;
    private Rigidbody rb;
    public Transform planet;

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.useGravity = false;
    }

    void FixedUpdate() {
        if (grounded) {
            // Calculate how fast we should be moving
            Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            targetVelocity = transform.TransformDirection(targetVelocity);
            targetVelocity *= speed;

            // Apply a force that attempts to reach our target velocity
            Vector3 velocity = rb.velocity;
            Vector3 velocityChange = (targetVelocity - velocity);
            velocityChange = Vector3.ClampMagnitude(velocityChange, maxVelocityChange);
            rb.AddForce(velocityChange, ForceMode.VelocityChange);

            // Jump
            if (canJump && Input.GetButton("Jump")) {
                rb.AddForce(transform.TransformVector(new Vector3(0, jumpHeight, 0)), ForceMode.Impulse);
            }
        }

        Vector3 g = (planet.position - transform.position).normalized;

        // We apply gravity manually for more tuning control
        rb.AddForce(g * gravity * rb.mass);

        grounded = false;
    }

    void OnCollisionStay() {
        grounded = true;
    }
}
