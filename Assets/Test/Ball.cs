using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public enum Type { Control, Delta, Fixed };

	public Type moveType;
	public float deltaX;
	public Rigidbody rb;

	// Use this for initialization
	void Start() {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update() {
		if (moveType == Type.Control) {
			transform.Translate(deltaX * Vector3.right);
		} else if (moveType == Type.Delta) {
			transform.Translate(deltaX * Time.deltaTime * Vector3.right);
		}
	}

	// Update is called once per fixed frame
	void FixedUpdate() {
		if (moveType == Type.Fixed) {
			//transform.Translate(new Vector3(deltaX, 0.0f));
			rb.AddForce(deltaX * Vector3.right);
		}
	}
}
