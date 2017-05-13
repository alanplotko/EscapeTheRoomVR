using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Collectable : MonoBehaviour {
	public Item item; // The object that will go into the inventory when this is picked up
	private Inventory inventory;
    public Material inactiveMaterial; // Default material for item (when not pointing at it)
    public Material gazedAtMaterial; // Highlight material for item (to show it's inspectable)
    public UnityEvent dispatch; // Callback

	void Awake() {
		Debug.Log("init collectable");
		inventory = FindObjectOfType<Inventory>();
		if (inventory == null) {
			Debug.Log("Couldn't find inventory!");
		}
	}

	void Start() {
		SetGazedAt(false);
	}

	public void Collect() {
        if (item) {
            Debug.Log("Picked up " + item.name + "!");
            // Add item to inventory and remove item from scene
            inventory.AddItem(item);
            GameObject.Destroy(gameObject);
        }
        if (dispatch != null) dispatch.Invoke(); // Callback
	}

	public void SetGazedAt(bool gazedAt) {
        // Show material corresponding to controller's laser pointer location
		if (inactiveMaterial != null && gazedAtMaterial != null) {
			GetComponent<Renderer>().material = gazedAt ? gazedAtMaterial : inactiveMaterial;
			return;
		}
	}
}
