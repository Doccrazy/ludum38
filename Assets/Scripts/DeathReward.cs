using UnityEngine;
using System.Collections;

public class DeathReward : MonoBehaviour {
    public int reward;

    private void OnDestroy() {
        GameObject player = GameObject.Find("Player");
        if (player != null) {
            player.GetComponent<Money>().amount += reward;
        }
    }
}
