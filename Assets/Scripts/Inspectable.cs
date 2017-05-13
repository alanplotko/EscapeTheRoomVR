using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspectable : MonoBehaviour {

	public string inspectMessage;

	public void Inspect() {
        // Show default observation text
		Inspect(inspectMessage);
	}

	public void Inspect(string msg) {
        // Show specific message in response to use of item
		GameObject.Find("SubtitlesCanvas/MessageText").GetComponent<ShowMessage>().RunMessage(msg);
	}
}
