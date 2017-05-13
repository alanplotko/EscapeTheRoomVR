using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePillow : MonoBehaviour {
    public Lightable[] lamps = new Lightable[2];
    public GameObject key; // Hack to hide key
    bool isMoved = false;

    void Start() {
        GetComponent<Inspectable>().enabled = false;
        GetComponent<Collectable>().enabled = false;
        GetComponent<Collider>().enabled = false;
        key.GetComponent<Collider>().enabled = false;
    }

    void Update() {
        if (!isMoved && (lamps[0].on || lamps[1].on)) {
            SetInteractable (true);
        } else {
            SetInteractable (false);
        }
    }

    public void SetInteractable(bool status) {
        GetComponent<Inspectable>().enabled = status;
        GetComponent<Collectable>().enabled = status;
        GetComponent<Collider>().enabled = status;
    }

    void SetKey(bool status) {
        if (key != null) {
            key.GetComponent<Collider> ().enabled = status;
        }
    }

    // Move pillow aside to reveal the hidden key
    public void MovePillowAway() {
        transform.Translate(0.5f, 0, 0);
        isMoved = true;
        SetKey (true);
    }
}
