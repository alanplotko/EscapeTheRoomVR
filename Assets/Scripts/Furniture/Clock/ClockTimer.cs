using UnityEngine;
using System.Collections;

public class ClockTimer : MonoBehaviour {
	public int initialHoursValue;
	public int initialMinutesValue;
	public int initialSecondsValue;
	public float clockSpeed=1.0f;
	public bool pointFlicker=true;
	public bool reverse=false;


	private DigitalClock digitalClock;
	private AnalogicClock analogicClock;
	// Use this for initialization
	void OnEnable () {
		digitalClock = transform.GetComponentInChildren<DigitalClock> ();
		analogicClock = transform.GetComponentInChildren<AnalogicClock>();
		if (digitalClock != null) {
			digitalClock.clockSpeed = clockSpeed;
			digitalClock.SetReverseClock(reverse);
			if (!pointFlicker)digitalClock.pointFlicker=false;
			if (digitalClock.hoursDCV!=null)digitalClock.hoursDCV.ChangeToTargetTime (initialHoursValue);
			if (digitalClock.minutesDCV!=null)digitalClock.minutesDCV.ChangeToTargetTime (initialMinutesValue);
			if (digitalClock.secondsDCV!=null)digitalClock.secondsDCV.ChangeToTargetTime (initialSecondsValue);
		}
		if (analogicClock != null) {
			if (reverse)analogicClock.clockSpeed=-clockSpeed;
			else analogicClock.clockSpeed=clockSpeed;
			analogicClock.SetTime(initialHoursValue,initialMinutesValue,initialSecondsValue);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (digitalClock != null) {
			digitalClock.clockSpeed = clockSpeed;
		}
	}
}
