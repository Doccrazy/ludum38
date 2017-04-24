using UnityEngine;
using System.Collections;

public class LevelProgression : MonoBehaviour {
    public LevelProgression nextLevel;
    private bool movedOn;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void FixedUpdate() {
        EnemySpawner[] allSpawners = GetComponentsInChildren<EnemySpawner>();
        bool allSpawned = true;
        foreach (EnemySpawner spawner in allSpawners) {
            if (spawner.amount > 0) {
                allSpawned = false;
                break;
            }
        }
        if (allSpawned && !movedOn) {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) {
                Invoke("ToNextLevel", 2);
                movedOn = true;
            }
        }
    }

    void ToNextLevel() {
        gameObject.SetActive(false);
        if (GameObject.Find("Player") == null) {
            return;
        }
        if (nextLevel != null) {
            nextLevel.gameObject.SetActive(true);
        } else if (Camera.main != null) {
            Camera.main.enabled = false;
            GameObject.Find("OutsideCamera").GetComponent<Camera>().enabled = true;
        }
    }
}
