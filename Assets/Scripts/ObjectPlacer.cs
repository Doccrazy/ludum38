using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPlacer : MonoBehaviour {
    public AbstractWeapon[] availableTowers;
    public Transform ground;
    public Material templateMaterial;
    public Material templateInvalidMaterial;
    public Money money;
    public Text hintText;

    private float boundsSpacing = 1.2f;
    protected AbstractWeapon selectedObject;
    private GameObject template;
    private float templateHeight;

    // Use this for initialization
    void Start() {
    }

    protected virtual void Select(AbstractWeapon obj) {
        if (template != null)
        {
            Destroy(template);
        }
        if (obj == null || money.amount < obj.GetCost()) {
            selectedObject = null;
            hintText.text = "";
            return;
        }
        selectedObject = obj;
        hintText.text = selectedObject.GetHint();
        template = Instantiate(selectedObject.gameObject, Vector3.zero, Quaternion.identity, ground);
        template.GetComponent<Collider>().enabled = false;
        foreach (Behaviour b in template.GetComponents<Behaviour>()) {
            b.enabled = false;
        }
        UpdateRenderers(template, false, templateMaterial);

        float height = template.GetComponent<BoxCollider>().size.y;
        templateHeight = height * template.transform.localScale.y * ground.localScale.y;
    }

    // Update is called once per frame
    void Update() {
        UpdateSelection();

        if (selectedObject != null && template != null) {
            RaycastHit hit;
            bool onGround = false, valid = false;
            Transform direction = GetDirection();
            if (direction != null && Physics.Raycast(direction.transform.position, direction.transform.forward, out hit, 1000f, 1 << 9)) {
                template.transform.position = hit.point + hit.normal * templateHeight / 2f;
                Vector3 forward = Vector3.ProjectOnPlane(direction.transform.forward, hit.normal).normalized;
                template.transform.rotation = Quaternion.LookRotation(forward, hit.normal);
                onGround = true;

                Vector3 boxExtent = Vector3.Scale((template.GetComponent<BoxCollider>().size / 2) * boundsSpacing, template.transform.lossyScale);
                if (!Physics.CheckBox(template.transform.position, boxExtent, template.transform.rotation, 1 << 11)) {
                    valid = true;
                }
            }
            UpdateRenderers(template, onGround, valid ? templateMaterial : templateInvalidMaterial);

            TryPlace(valid);
        }
    }

    protected virtual void UpdateSelection() {
        if (Input.GetKeyDown(KeyCode.Alpha1) && availableTowers.Length > 0) {
            Select(availableTowers[0]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && availableTowers.Length > 1) {
            Select(availableTowers[1]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && availableTowers.Length > 2) {
            Select(availableTowers[2]);
        }
    }

    protected virtual Transform GetDirection() {
        return Camera.main != null ? Camera.main.transform : null;
    }

    protected virtual void TryPlace(bool valid) {
        if (Input.GetMouseButtonDown(0) && valid) {
            Place();
        }
    }

    protected virtual void Place() {
        Instantiate(selectedObject.gameObject, template.transform.position, template.transform.rotation, ground);
        money.amount -= selectedObject.GetCost();
        if (money.amount < selectedObject.GetCost()) {
            Select(null);
        }
    }

    private void UpdateRenderers(GameObject obj, bool enabled, Material material) {
        foreach (Renderer r in obj.GetComponentsInChildren<Renderer>()) {
            r.enabled = enabled;
            r.material = material;
            r.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        }
    }
}
