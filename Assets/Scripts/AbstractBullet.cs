using UnityEngine;
using System;

public abstract class AbstractBullet : MonoBehaviour {
    protected float damage;
    internal abstract void Target(Vector3 fireDir, Transform enemy);

    protected void Expire() {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Destructible>() != null) {
            other.GetComponent<Destructible>().Damage(this.gameObject, damage);
        }
        Destroy(gameObject);
    }
}
