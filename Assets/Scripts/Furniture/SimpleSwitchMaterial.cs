using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SimpleSwitchMaterial : MonoBehaviour {

	// Use this for initialization
	public Material[] initialMaterials;
	public Material[] newMaterials;

	public void SwitchMaterial(){
		if (initialMaterials.Length==newMaterials.Length){
			MeshRenderer[] allVisibleMeshRenderers = GameObject.FindObjectsOfType<MeshRenderer> ();
			foreach(MeshRenderer mesh in allVisibleMeshRenderers){
				for (int i=0;i<initialMaterials.Length;i++){
					if (mesh.sharedMaterial==initialMaterials[i]){
						mesh.sharedMaterial=newMaterials[i];
						break;
					}
				}
			}
		}
		else Debug.Log ("initial Material variable Array length is different than new Materials variable Array length, please fix :)");
	}
	public void SwitchMaterialReverse(){
		if (initialMaterials.Length==newMaterials.Length){
			MeshRenderer[] allVisibleMeshRenderers = GameObject.FindObjectsOfType<MeshRenderer> ();
			foreach(MeshRenderer mesh in allVisibleMeshRenderers){
				for (int i=0;i<initialMaterials.Length;i++){
					if (mesh.sharedMaterial==newMaterials[i]){
						mesh.sharedMaterial=initialMaterials[i];
						break;
					}
				}
			}
		}
		else Debug.Log ("initial Material variable Array length is different than new Materials variable Array length, please fix :)");
	}
}
