using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTower : AbstractWeapon {
    public AbstractBullet rocket;
    public float fireHeight;

    RocketTower() {
        fireRate = 5;
        maxAngle = 75;
    }

    override protected bool TryFire () {
        GameObject enemy = FindEnemy(true);
        if (enemy != null) {
            AbstractBullet r = Instantiate(rocket, transform.TransformPoint(Vector3.up * fireHeight), Quaternion.LookRotation(transform.TransformDirection(Vector3.up)));
            r.Target(transform.up, enemy.transform);
            return true;
        }
        return false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
