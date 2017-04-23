using UnityEngine;
using System.Collections;

public class MultishotTower : AbstractWeapon {
    public AbstractBullet bullet;
    public float fireHeight;

    MultishotTower() {
        fireRate = Constants.MULTISHOT_RATE;
        maxAngle = 80;
    }

    protected override bool TryFire() {
        GameObject enemy = FindEnemy(true);
        if (enemy != null) {
            AbstractBullet b = Instantiate(bullet, transform.TransformPoint(Vector3.up * fireHeight), Quaternion.LookRotation(transform.TransformDirection(Vector3.up)));
            b.Target(transform.up, enemy.transform);
            return true;
        }
        return false;
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public override int GetCost() {
        return Constants.ROCKET_COST;
    }
}
