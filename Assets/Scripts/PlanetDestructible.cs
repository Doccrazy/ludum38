using UnityEngine;
using System.Collections;

public class PlanetDestructible : Destructible {
    public Camera outsideCamera;

    override public void Kill() {
        if (Camera.main != null) {
            Camera.main.enabled = false;
        }
        outsideCamera.enabled = true;

        Invoke("DoKill", 2);
    }

    private void DoKill() {
        base.Kill();
    }
}
