using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightable : MonoBehaviour {
    public bool on { get; private set; }

    // Lightable game objects are off by default at start
	public void Start() {
        on = false;
		gameObject.GetComponentInChildren<Light>().enabled = false;
	}

	public void ToggleLight() {
        // Toggle light switch
        on = !on;
		gameObject.GetComponentInChildren<Light> ().enabled = 
			!gameObject.GetComponentInChildren<Light> ().enabled;
		// Change message based on light switch position
        if (on) {
			gameObject.GetComponent<Inspectable>().inspectMessage = "That's much better...";
		} else {
			gameObject.GetComponent<Inspectable>().inspectMessage = "Hello darkness, my old friend...";
		}


	}
}
