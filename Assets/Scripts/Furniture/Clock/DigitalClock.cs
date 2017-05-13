using UnityEngine;
using System.Collections;

public class DigitalClock : MonoBehaviour {
	public DigitalClockValue hoursDCV;
	public DigitalClockValue minutesDCV;
	public DigitalClockValue secondsDCV;
	public DigitalClockValue pointsDCV;
	public bool pointFlicker = true;
	public float clockSpeed;
    public int score { get; set; }

	void Start() {
		StartCoroutine ("PlayTime");
		if (pointFlicker && secondsDCV == null) StartCoroutine ("PlayPointFlicker");
	}

	public void SetReverseClock(bool setReverse){
		if (hoursDCV != null)
			hoursDCV.reverse = setReverse;
		if (minutesDCV != null)
			minutesDCV.reverse = setReverse;
		if (secondsDCV != null)
			secondsDCV.reverse = setReverse;
	}

	IEnumerator PlayTime(){
		while (true) {
			if (secondsDCV!=null){
				yield return new WaitForSeconds (1.0f /clockSpeed);
				secondsDCV.ChangeTimeValue();
				if (pointFlicker) {
					pointsDCV.ChangeTimeValue ();
                    int hours = hoursDCV.currentValue,
                        minutes = minutesDCV.currentValue;
					GameObject.FindGameObjectWithTag("clock").GetComponent<Inspectable> ().inspectMessage = 
                        string.Format ("It reads {0:D2}:{1:D2}.", hours, minutes);
                    score = (hours * 60) + minutes;
				}
			}
			else {
				yield return new WaitForSeconds (60.0f/clockSpeed);
                minutesDCV.ChangeTimeValue ();
                int hours = hoursDCV.currentValue,
                minutes = minutesDCV.currentValue;
                GameObject.FindGameObjectWithTag ("clock").GetComponent<Inspectable> ().inspectMessage = 
                    string.Format ("It reads {0:D2}:{1:D2}.", hours, minutes);
                score = (hours * 60) + minutes;
			}
		}
	}
	IEnumerator PlayPointFlicker(){
		while (pointFlicker) {
			yield return new WaitForSeconds (1.0f /clockSpeed);
			pointsDCV.ChangeTimeValue ();
		}
	}
}
