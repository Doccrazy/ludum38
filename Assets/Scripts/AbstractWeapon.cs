using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWeapon : MonoBehaviour {
    protected float maxAngle = 10;
    protected float fireRate = 1;
    protected float initialDelay = 1;
    private float lastFireTime = -9999;

    private void FixedUpdate() {
        if (lastFireTime == -9999) {
            lastFireTime = Time.fixedTime - fireRate + initialDelay;
        } else if (Time.fixedTime - lastFireTime > fireRate) {
            if (TryFire()) {
                lastFireTime = Time.fixedTime;
            }
        }
    }

    protected abstract bool TryFire();

    protected GameObject FindEnemy(bool random) {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        List<GameObject> candidates = new List<GameObject>();
        foreach (GameObject enemy in enemies) {
            Vector3 to = enemy.transform.position - transform.position;
            float angle = Vector3.Angle(to, transform.up);
            if (angle < maxAngle) {
                candidates.Add(enemy);
            }
        }
        return candidates.Count > 0 ? candidates[random ? Random.Range(0, candidates.Count) : 0] : null;
    }

    public abstract int GetCost();
}
