using UnityEngine;
using System.Collections;

//[ExecuteInEditMode]
public class DigitalClockValue : MonoBehaviour {
	public int currentValue;
	private int lastValue;
	public int maximumValue;
	public DigitalClockValue NextValue;
	public DisplaySelectedObject tens;
	public DisplaySelectedObject units;
	public int tensValue=10;
	public bool reverse=false;

	public void ChangeToTargetTime(int value){
		if (!reverse)
			currentValue = value-1;
		else 
			currentValue = value+1;
		if (value > maximumValue)
			value = maximumValue - 1;
		if (value < 0)
			value = 0;
		ChangeTimeValue ();
	}

	public void ChangeTimeValue(){
		if (!reverse)
			currentValue += 1;
		else 
			currentValue -= 1;
		if (currentValue > maximumValue - 1) {
			currentValue = 0;
			if (NextValue != null)
				NextValue.ChangeTimeValue ();
		}
		if (currentValue < 0) {
			currentValue = maximumValue - 1;
			if (NextValue != null)
				NextValue.ChangeTimeValue ();
		}

		if (tens!=null)tens.TurnSelectedWithButton (currentValue/tensValue);
		units.TurnSelectedWithButton (currentValue % tensValue);
	}
}
