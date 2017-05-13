using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {
	private bool isVisible;

	void Start() {
		isVisible = false;
	}

	// Update is called once per frame
	void Update () {
		if (GvrController.AppButtonUp) {
			ToggleVisibility();
		}
	}

	public void ToggleVisibility() {
		CanvasGroup cg = GetComponent<CanvasGroup>();
		if (isVisible) {
			cg.alpha = 0;
		} else {
			cg.alpha = 1;
		}
		isVisible = !isVisible;
	}
}
