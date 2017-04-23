using UnityEngine;
using System.Collections;

public abstract class AbstractLevel : MonoBehaviour {
    public GameObject planet;
    public GameObject normalEnemy;
    public Material normalIndicatorMat;
    public GameObject attackIndicator;

    protected float indicatorDistance = 20;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    protected void CreateIndicator(AttackDef ad) {
        Vector3 pos = planet.transform.position - ad.dir * indicatorDistance;
        GameObject indicator = Instantiate(attackIndicator, pos, Quaternion.LookRotation(-Vector3.ProjectOnPlane(Vector3.up, ad.dir), ad.dir));
        indicator.GetComponent<Renderer>().material = GetIndMat(ad.type);
        indicator.GetComponentInChildren<TextMesh>().text = "Expect " + ad.amount + " " + ad.type;
    }

    protected Material GetIndMat(string type) {
        if (type == "normal") {
            return normalIndicatorMat;
        }
        throw new System.Exception();
    }

    protected GameObject GetEnemy(string type) {
        if (type == "normal") {
            return normalEnemy;
        }
        throw new System.Exception();
    }

    protected Vector3 GetRandomSpawnPoint(AttackDef ad) {
        Vector3 center = planet.transform.position - ad.dir * ad.distance;
        Vector3 offset = Vector3.ProjectOnPlane(Quaternion.Euler(0, Random.Range(-ad.angleHor, ad.angleHor), 0) * (-ad.dir * ad.distance), ad.dir);
        return center + offset;
    }
}

public class AttackDef {
    public Vector3 dir;
    public float distance = 50;
    public float angleHor = 15;
    public float angleVer = 0;
    public int amount;
    public string type;

    public AttackDef(Vector3 dir, int amount, string type) {
        this.dir = dir;
        this.amount = amount;
        this.type = type;
    }
}
