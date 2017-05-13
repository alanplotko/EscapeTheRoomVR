using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SimpleSwitchMaterial))]
public class EditorSimpleSwitchMaterial : Editor 
{
	
	public override void OnInspectorGUI()
	{
		SimpleSwitchMaterial myTarget = (SimpleSwitchMaterial)target;
		
		if (myTarget != null) {
			DrawDefaultInspector ();
			if (GUILayout.Button ("Switch from PC Materials to Mobile materials",GUILayout.Height(50.0f))) {
				myTarget.SwitchMaterial ();
			}
			if (GUILayout.Button ("Switch from Mobile Materials to PC materials",GUILayout.Height(50.0f))) {
				myTarget.SwitchMaterialReverse ();
			}
		}
	}
}