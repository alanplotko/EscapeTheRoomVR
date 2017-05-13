using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySelect : MonoBehaviour {
	private Inventory inventory;
	public int index;

	void Awake() {
		inventory = gameObject.GetComponentInParent<Inventory>();
	}

	public void Select() {
		inventory.SelectItem(index);
	}
}
