using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartHelper : MonoBehaviour {

    private void Update() {
        transform.Find("RestartButton").gameObject.SetActive(Camera.main == null);
    }

    public void Restart() {
        SceneManager.LoadScene("Main");
    }
}
