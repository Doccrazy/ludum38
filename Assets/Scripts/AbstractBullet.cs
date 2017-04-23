using UnityEngine;
using UnityEditor;
using System;

public abstract class AbstractBullet : MonoBehaviour {
    internal abstract void Target(Vector3 fireDir, Transform enemy);

    protected void Expire() {
        Destroy(gameObject);
    }
}
