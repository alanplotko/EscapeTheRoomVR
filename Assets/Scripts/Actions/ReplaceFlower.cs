using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceFlower : MonoBehaviour {

	private GameObject flower;

	void Start() {
		flower = GameObject.FindWithTag("flower");
		flower.SetActive(false);
	}

    // Add flower from desk to vase
	public void PlaceFlower() {
		flower.SetActive(true);
        GameObject.FindWithTag("mirror").GetComponent<Usable>().inspectMessage = "The flower isn't in the reflection...";
        GameObject.FindWithTag("vase").GetComponent<Collectable>().enabled = false;
        GameObject.FindWithTag("vase").GetComponent<Usable>().enabled = false;
        GameObject.FindWithTag("vase").GetComponent<Collider>().enabled = false;
	}
}
