using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Usable : Inspectable {
    public Item useItem;
    public string successMessage, failureMessage;
    public UnityEvent dispatch;  // Callback

    public void Use(Inventory inv) {
        // Check if item matches what’s expected
        if (inv.SelectedItem == null) {
            Inspect(); // Item is not usable
        } else if (inv.SelectedItem == useItem) {
            Inspect(successMessage);
            inv.RemoveItem(useItem);
            if (dispatch != null) dispatch.Invoke();
        } else {
            Inspect(failureMessage);
        }
    }
}

