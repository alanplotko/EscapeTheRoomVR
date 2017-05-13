using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class DisplaySelectedObject : MonoBehaviour {
	public GameObject[] displayOptions; //Do not comment or change this variable, local values have been assigned to every prefab
	public int currentDisplay;
	private int oldDisplay;
	public int temporalGOArrange=0;		//Temporal Variable
	public bool ButtonSelectable=true;

	void OnEnable () {
		//temporalGOArrange = 0;
		if (temporalGOArrange == 1) {		//Temporal script
			TemporalMethodArrangeModels ();
			TemporalPlaceArrangeModels();
		} else {
			if (displayOptions.Length > 0) {
				TurnOffAll (); 																	//Activate off every object in the array
				displayOptions [currentDisplay].SetActive (true); 								//Activate on the currently selected GameObject (currentDisplay);
				oldDisplay = currentDisplay; 													//Since the gameObject we needed is already Activated, we save it in oldDisplay so when CurrentDisplay option changes, OldDisplay turns off the last GameObject Activated this way
			}
		}
	}


	void TurnOffAll(){
		if (displayOptions.Length > 0) {
			for (int i=0; i<displayOptions.Length; i++) {
				displayOptions [i].SetActive (false); 										//turn off every GameObject Iniside displayOptions Array
			}
		}
	}

	public void TurnSelectedWithButton(int curDisp){
		currentDisplay = curDisp;
		if (curDisp != oldDisplay) {
			displayOptions [oldDisplay].SetActive(false); 
			displayOptions [curDisp].SetActive(true);
			oldDisplay=curDisp;
		}
		
	}

	void TemporalMethodArrangeModels(){		//TemporalScript
		Transform[] transformChild = GetComponentsInChildren<Transform> ();
		int childCounter=0;
		int childAssign=0;
		for (int i=1; i<transformChild.Length; i++) {
			if (transformChild[i].parent.gameObject==this.gameObject)childCounter++;
		}
		displayOptions=new GameObject[childCounter];
		for (int j=1; j<transformChild.Length; j++) {
			if (transformChild[j].parent.gameObject==this.gameObject){
				displayOptions[childAssign]=transformChild[j].gameObject;
				childAssign++;
			}
			//displayOptions=new GameObject[1];
		}
		childCounter = 0;
		childAssign = 0;

	}
	void TemporalPlaceArrangeModels(){
		Transform[] transformChild = GetComponentsInChildren<Transform> ();
		for (int i=1; i<transformChild.Length; i++) {
			for (int j=0;j<displayOptions.Length;j++){
				if (displayOptions[j].name.Contains(i+"_")){
					displayOptions[j].transform.SetAsLastSibling();
				}
//				if (displayOptions[j].name.Contains("Wood Atlas"))displayOptions[j].transform.SetAsLastSibling();
//				//if (displayOptions[j].name.Contains("Marble Atlas"))displayOptions[j].transform.SetAsLastSibling();
//				if (displayOptions[j].name.Contains("Metal Atlas"))displayOptions[j].transform.SetAsLastSibling();
//				if (displayOptions[j].name.Contains("Plastic Atlas"))displayOptions[j].transform.SetAsLastSibling();
//				if (displayOptions[j].name.Contains("Quarry Atlas"))displayOptions[j].transform.SetAsLastSibling();
//				if (displayOptions[j].name.Contains("Glass Shine"))displayOptions[j].transform.SetAsLastSibling();
			}
		}
	}
}
