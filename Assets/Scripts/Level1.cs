using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : AbstractLevel {
    private AttackDef[] attacks = {
        new AttackDef(new Vector3(1, 0, 0), 10, "normal"),
        new AttackDef(new Vector3(-1, 0, 0), 10, "normal"),
        new AttackDef(new Vector3(0, 0, 1), 10, "normal"),
        new AttackDef(new Vector3(0, 0, -1), 10, "normal"),
    };

	// Use this for initialization
	void Start () {
        foreach (AttackDef ad in attacks) {
            CreateIndicator(ad);
        }
        Invoke("StartAttack", 3f);
	}

    void StartAttack() {
        foreach (GameObject ind in GameObject.FindGameObjectsWithTag("Indicator")) {
            Destroy(ind);
        }
        InvokeRepeating("Spawn", 0, 1f);
    }

    void Spawn() {
        foreach (AttackDef ad in attacks) {
            if (ad.amount > 0) {
                ad.amount--;
                Vector3 spawn = GetRandomSpawnPoint(ad);
                GameObject enemy = Instantiate(GetEnemy(ad.type), spawn, Quaternion.LookRotation(ad.dir, Vector3.ProjectOnPlane(Vector3.up, ad.dir)));
                enemy.GetComponent<Rigidbody>().velocity = (planet.transform.position - enemy.transform.position).normalized * Random.Range(2f, 3f);
                foreach (TriangleExplosion t in enemy.GetComponentsInChildren<TriangleExplosion>()) {
                    t.Explode();
                }
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
		
	}
}
