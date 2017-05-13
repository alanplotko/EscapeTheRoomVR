using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateDrawer : MonoBehaviour {
    private Vector3 origin;

    // Use this for initialization
    void Start() {
        origin = transform.parent.position;
        transform.parent.FindChild ("Knife").transform.parent = transform.parent.transform;
    }

    // Show transition for opening drawer
    public void OpenDrawer() {
        Debug.Log("Opening drawer");
        transform.parent.transform.Translate(0, 0, 0.5f);
        GetComponent<Usable>().enabled = false;
        GetComponent<Collectable>().enabled = false;
        GetComponent<Collider>().enabled = false;
    }
}