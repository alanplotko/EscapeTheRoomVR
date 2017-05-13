using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class AnalogicClock : MonoBehaviour {
	public GameObject hoursHand;
	public GameObject minutesHand;
	public GameObject secondsHand;

	public float clockSpeed=1.0f;

	public bool getHands=false;
	// Update is called once per frame

	void OnEnable(){
		if (getHands)AssignHands ();
	}
	void Update () {

		if (!getHands)
			PlayTime ();
		
	}
	public void AssignHands(){
		Transform[] transChild = transform.GetComponentsInChildren<Transform> (true);
		foreach (Transform transformChild in transChild) {
			if (transformChild.name.Contains("ong"))
				minutesHand=transformChild.gameObject;
			if (transformChild.name.Contains("econdsHand"))
				secondsHand=transformChild.gameObject;
			if (transformChild.name.Contains("mallHand"))
				hoursHand=transformChild.gameObject;
		}
	}
	public void SetTime(int hours, int minutes, int seconds){

		if (secondsHand != null)
			secondsHand.transform.Rotate (new Vector3(0,0,seconds*6));
		minutesHand.transform.Rotate (new Vector3(0,0,(minutes+(seconds/60.0f))*6));
		hoursHand.transform.Rotate (new Vector3(0,0,(hours+(minutes/60.0f))*30));
	}

	void PlayTime(){
		hoursHand.transform.Rotate (Vector3.forward*Time.deltaTime*0.00833f*clockSpeed);
		minutesHand.transform.Rotate (Vector3.forward*Time.deltaTime*0.1f*clockSpeed);
		if (secondsHand!=null)secondsHand.transform.Rotate (Vector3.forward*Time.deltaTime*6.0f*clockSpeed);
	}
}
