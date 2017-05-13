using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CleanUpAll))]
public class EditorCleanUpAll : Editor 
{
	
	public override void OnInspectorGUI()
	{
		CleanUpAll myTarget = (CleanUpAll)target;
		
		if (myTarget != null) {
			DrawDefaultInspector ();
			if (GUILayout.Button ("Clean Up all Scene",GUILayout.Height(50.0f))) {
				myTarget.CleanupScene ();
			}
		}
	}
}
