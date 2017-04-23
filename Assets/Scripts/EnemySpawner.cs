using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;
    public int amount = 10;
    public int delay = 30;
    public float spawnRate = 1f;
    private EnemyType type;
    private Transform spawnArea;

    // Use this for initialization
    void Start () {
        spawnArea = transform.FindChild("SpawnArea");
        type = enemyPrefab.GetComponent<EnemyType>();

        transform.FindChild("AttackIndicator").GetComponent<MeshRenderer>().material.color = type.color;
        transform.FindChild("AttackIndicator").transform.FindChild("Text").GetComponent<TextMesh>().color = Brighten(type.color);

        Invoke("StartAttack", delay);
        InvokeRepeating("CountDown", 0, 1);
    }

    private Color Brighten(Color c) {
        float h, s, v;
        Color.RGBToHSV(c, out h, out s, out v);
        return Color.HSVToRGB(h, s * 0.6f, v);
    }

    void CountDown() {
        GetComponentInChildren<TextMesh>().text = "Expect " + amount + " " + type.type + " in " + delay;
        delay--;
        if (delay <= 0) {
            CancelInvoke("CountDown");
        }
    }
    
    void StartAttack() {
        Destroy(transform.FindChild("AttackIndicator").gameObject);
        InvokeRepeating("Spawn", 0, spawnRate);
    }

    void Spawn() {
        if (amount > 0) {
            GameObject planet = GameObject.Find("Planet");
            if (planet == null) {
                return;
            }

            amount--;
            Vector3 p1 = spawnArea.transform.TransformPoint(-0.5f, -0.5f, -0.5f);
            Vector3 p2 = spawnArea.transform.TransformPoint(0.5f, 0.5f, 0.5f);
            Vector3 spawn = new Vector3(Random.Range(p1.x, p2.x), Random.Range(p1.y, p2.y), Random.Range(p1.z, p2.z));
            Vector3 dir = (planet.transform.position - spawn).normalized;
            GameObject enemy = Instantiate(enemyPrefab, spawn, Quaternion.LookRotation(dir, Vector3.ProjectOnPlane(Vector3.up, dir)));
            enemy.GetComponent<Rigidbody>().velocity = dir * type.RandomInitVelocity();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
