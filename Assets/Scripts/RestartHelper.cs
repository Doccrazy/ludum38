using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartHelper : MonoBehaviour {

    private void Update() {
        transform.Find("RestartButton").gameObject.SetActive(GameObject.Find("Player") == null);
        transform.Find("LooseLabel").gameObject.SetActive(GameObject.Find("Player") == null);
    }

    public void Restart() {
        SceneManager.LoadScene("Main");
    }
}
