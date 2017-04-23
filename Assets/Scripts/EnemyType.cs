using UnityEngine;
using System.Collections;

public class EnemyType : MonoBehaviour {
    public string type = "normal";

    public Color color {
        get {
            Color col = new Color(1, 0, 1);
            if (type == "normal") {
                col = new Color(0, 0, 1, 0.75f);
            } else if (type == "mass") {
                col = new Color(1, 1, 0, 0.75f);
            } else if (type == "boss") {
                col = new Color(1, 0, 0, 0.75f);
            }
            return col;
        }
    }

    public float RandomInitVelocity() {
        if (type == "normal") {
            return Random.Range(1f, 1.5f);
        } else if (type == "mass") {
            return Random.Range(2f, 3f);
        } else if (type == "boss") {
            return Random.Range(0.5f, 1f);
        }
        throw new System.Exception();
    }
}
