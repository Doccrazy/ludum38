using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTower : AbstractWeapon {
    public AbstractBullet laserShot;
    public float fireHeight;

    LaserTower() {
        fireRate = Constants.LASER_RATE;
        maxAngle = 25;
    }

    protected override bool TryFire() {
        GameObject enemy = FindEnemy(false);
        if (enemy != null) {
            AbstractBullet r = Instantiate(laserShot, transform.TransformPoint(Vector3.up * fireHeight), Quaternion.LookRotation(transform.TransformDirection(Vector3.up)));
            r.Target(transform.up, enemy.transform);
            return true;
        }
        return false;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override int GetCost() {
        return Constants.LASER_COST;
    }

    public override string GetHint() {
        return "Laser towers only cover a very limited area with quite good damage.";
    }
}
