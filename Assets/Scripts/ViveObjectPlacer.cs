using System;
using UnityEngine;

public class ViveObjectPlacer : ObjectPlacer {
    public Texture[] PreviewTextures;
    private readonly String[] hints = {
        "Rocket\nTower\n\n<color=\"yellow\"><b>$" + Constants.ROCKET_COST + "</b></color>",
        "Laser\nTower\n\n<color=\"yellow\"><b>$" + Constants.LASER_COST + "</b></color>",
        "Multishot\nTower\n\n<color=\"yellow\"><b>$" + Constants.MULTISHOT_COST + "</b></color>"
    };

    private int selectIdx = 0;

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_TrackedController trackedController;

    private SteamVR_Controller.Device Controller {
        get { return SteamVR_Controller.Input((int) trackedObj.index); }
    }

    void Awake() {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        trackedController = GetComponent<SteamVR_TrackedController>();
        trackedController.PadClicked += Controller_PadClicked;
        Select(availableTowers[selectIdx]);
    }

    private void Controller_PadClicked(object sender, ClickedEventArgs clickedEventArgs) {
        if (Controller.GetAxis().x > 0) {
            selectIdx = (selectIdx + 1) % availableTowers.Length;
        }
        else {
            selectIdx = (selectIdx + availableTowers.Length - 1) % availableTowers.Length;
        }
        Select(availableTowers[selectIdx]);
    }

    protected override void Select(AbstractWeapon tower) {
        base.Select(tower);
        if (selectedObject != null) {
            transform.FindChild("TowerPreview").GetComponent<MeshRenderer>().enabled = true;
            transform.FindChild("TowerPreview").GetComponent<MeshRenderer>().material.mainTexture = PreviewTextures[selectIdx];
            transform.FindChild("TowerHint").GetComponent<TextMesh>().text = hints[selectIdx];
        }
        else {
            transform.FindChild("TowerPreview").GetComponent<MeshRenderer>().enabled = false;
            transform.FindChild("TowerHint").GetComponent<TextMesh>().text = "<color=\"red\">" + hints[selectIdx] + "</color>";
        }
    }

    protected override void UpdateSelection() {
        //handled in Controller_PadClicked
    }

    protected override Transform GetDirection() {
        //controller point direction
        return transform;
    }

    protected override void TryPlace(bool valid) {
        if (Controller.GetHairTriggerDown()) {
            if (valid) {
                Place();
            }
            else {
                Controller.TriggerHapticPulse(2000);
            }
        }
    }
}