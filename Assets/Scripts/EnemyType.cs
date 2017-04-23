using UnityEngine;
using System.Collections;

public class EnemyType : MonoBehaviour {
    public string type = "normal";

    public Color color {
        get {
            Color col = new Color(1, 0, 1);
            if (type == "normal") {
                col = new Color(0, 0, 1, 0.75f);
            } else if (type == "fast") {
                col = new Color(1, 1, 0, 0.75f);
            } else if (type == "boss") {
                col = new Color(1, 0, 0, 0.75f);
            }
            return col;
        }
    }

    public float RandomInitVelocity() {
        if (type == "normal") {
            return Random.Range(2f, 3f);
        } else if (type == "fast") {
            return Random.Range(4f, 6f);
        } else if (type == "boss") {
            return Random.Range(1.5f, 2f);
        }
        throw new System.Exception();
    }
}
