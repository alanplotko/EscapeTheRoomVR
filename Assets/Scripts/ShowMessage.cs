using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

class ShowMessage : MonoBehaviour {
	private Text messageBox;
	private CanvasGroup canvasGroup;

    // Get necessary components at start
	void Start() {
		messageBox = gameObject.GetComponent<Text>();
		canvasGroup = gameObject.GetComponentInParent<CanvasGroup>();
	}

	public void RunMessage(String message) {
		StartCoroutine(ShowText(message));
	}

	private IEnumerator ShowText(String message) {
        // Set message
		messageBox.text = message;

        // Fade in message box if not visible
		while(canvasGroup.alpha < 1){
			canvasGroup.alpha += Time.deltaTime * 1f;
			yield return null;
		}

        // Wait 5 seconds before fading out
		yield return new WaitForSeconds(5f);

        // Fade out message box if visible
		while(canvasGroup.alpha > 0){
			canvasGroup.alpha -= Time.deltaTime * 1f;
			yield return null;
		}
	}
}