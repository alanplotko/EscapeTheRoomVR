using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
    private bool isVisible;
    public const int numItemSlots = 9;
	public Image[] itemImages = new Image[numItemSlots];
	public Item[] items = new Item[numItemSlots];
	public Item SelectedItem { get; private set; }

	void Start() {
		isVisible = false;
		SelectedItem = null;
	}

	void Update() {
        // If app button is pressed, show or hide inventory accordingly
		if (GvrController.AppButtonUp) {
			ToggleVisibility();
		}
	}

	public void ToggleVisibility() {
        // Get canvas where inventory is drawn
		CanvasGroup cg = GetComponent<CanvasGroup>();
        if (isVisible) { // Hide and let controller's laser pointer through
			cg.alpha = 0;
			cg.blocksRaycasts = false;
        } else { // Show and don't let controller's laser pointer through
			cg.alpha = 1;
			cg.blocksRaycasts = true;
		}
        // Toggle visibility
		isVisible = !isVisible;
	}

	public void AddItem(Item itemToAdd) {
        // Find first empty slot in inventory to place item
		for (int i = 0; i < items.Length; i++) {
			if (items[i] == null) {
                // Store item information
				items[i] =  itemToAdd;

                // Get corresponding cell of empty slot in inventory grid
				GameObject cell = GameObject.Find("Cell" + (i+1));
				itemImages[i] = cell.GetComponentInChildren<Image>();

                // Set item details for appearance in grid
				itemImages[i].sprite = itemToAdd.sprite;
				itemImages[i].enabled = true;
				itemImages[i].color = Color.white;

				return;
			}
		}
	}

	public void RemoveItem(Item itemToRemove) {
		for (int i = 0; i < items.Length; i++) {
            // Find the correct item to remove
			if (items[i] == itemToRemove) {
				items[i] = null; // Clear item

                // Reset correct item details for removing its appearance in grid
				itemImages[i].sprite = null;
				itemImages[i].enabled = false;
				itemImages[i].color = Color.clear;

                // If the item to remove is select, deselect it
                if (itemToRemove == SelectedItem) {
                    SelectedItem = null;
                }

				return;
			}
		}
	}

	public void SelectItem(int i) {
        // Set item as selected for later use with Usable game object
		SelectedItem = items[i];
		Debug.Log("Selected item: " + i);
	}
}
