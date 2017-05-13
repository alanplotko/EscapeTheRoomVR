using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CleanUpAll : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
		//CleanupAll ();
	}


	public void CleanupScene(){
		OptionsDisplay[] optionsDisplay = FindObjectsOfType (typeof(OptionsDisplay)) as OptionsDisplay[];
		foreach (OptionsDisplay option in optionsDisplay) {
			option.GOCleanup();
		}
	}
}
