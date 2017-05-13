using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class OptionsDisplay : MonoBehaviour {
	
	public DisplaySelectedObject[] displaySelectedObject;
	public DisplayFrame[] displayFrame;
	public float blindsOpenValue = 0.0f;

	public GameObject furnitureTextures;
	public OptionsDisplaySaveVar GlobalOptionsDisplaySaveVar;

	private GameObject digitalClockObject;
	void OnEnable(){

		#if UNITY_EDITOR
		furnitureTextures = GameObject.Find("_FurnitureDisplayTextures");
		if (furnitureTextures==null){ 
			furnitureTextures = new GameObject("_FurnitureDisplayTextures");
			furnitureTextures.tag="EditorOnly";
			GlobalOptionsDisplaySaveVar=furnitureTextures.AddComponent<OptionsDisplaySaveVar>();
			GlobalOptionsDisplaySaveVar.CreateDisplayTextures();
		}
		else{
			GlobalOptionsDisplaySaveVar=furnitureTextures.GetComponent<OptionsDisplaySaveVar>();
		}
		#endif

	}
	public void GOCleanup(){
		//clock section first part
		Transform groupPivots = transform.Find ("GroupPivots");
		Transform [] groupPivotsChilds=null;
		if (groupPivots != null) {
			groupPivotsChilds=groupPivots.GetComponentsInChildren<Transform>();
			groupPivots.SetParent (this.transform);
		}
		if (transform.GetComponentInChildren<DigitalClock>()!=null){
			digitalClockObject = transform.GetComponentInChildren<DigitalClock> ().gameObject;
			//if (digitalClockObject != null)
			digitalClockObject.transform.parent = null;
		}
		if (transform.GetComponentInChildren<AnalogicClock> () != null) {
			digitalClockObject = transform.GetComponentInChildren<AnalogicClock> ().gameObject;
			//if (digitalClockObject != null)
			digitalClockObject.transform.parent = null;
		}
		//clock section end first part
		Transform[]transformChildObjects=transform.GetComponentsInChildren<Transform> ();

		foreach (Transform transformChild in transformChildObjects) {
			if (transformChild!=this.transform){
				if (transformChild.GetComponent<MeshRenderer>()!=null ||
				    transformChild.GetComponent<Light>()!=null){
					transformChild.SetParent(this.transform);
				}
				if (transformChild.GetComponent<SkinnedMeshRenderer>()!=null){
					transformChild.parent.name="SKINNEDMESH";
						transformChild.parent.SetParent(this.transform);
				}
				if (transformChild.GetComponent<Collider>()!=null){
					if (!transformChild.parent.name.Contains("COLLIDER")){
						transformChild.SetParent(this.transform);
					}
				}
				if (transformChild.gameObject.name.Contains("COLLIDER")){
					if (!transformChild.parent.gameObject.name.Contains("COLLIDER")){
						transformChild.SetParent(this.transform);
					}
				}
				if (transformChild.name.Contains("grp")){
					if (groupPivotsChilds!=null){
						for (int i = 1; i<groupPivotsChilds.Length; i++){
							if (transformChild.name.Contains("grp"+(i.ToString()))){
								transformChild.SetParent(groupPivotsChilds[i]);
								break;
							}
						}
					}
				}
			}
		}
		GameObject meshGroup = new GameObject ();
		meshGroup.name = "MeshGroup";
		meshGroup.transform.SetParent (this.transform);
		foreach (Transform transformChild in transformChildObjects) {
			if (transformChild!=this.transform){
				if (transformChild!=null){
					if (transformChild.parent==this.transform){
						if (transformChild.GetComponent<SkinnedMeshRenderer>()==null && 
						    transformChild.GetComponent<MeshRenderer>()==null && 
						    transformChild.GetComponent<Light>()==null &&
						    transformChild.GetComponent<Collider>()==null &&
						    !transformChild.gameObject.name.Contains("COLLIDER")&&
						    !transformChild.gameObject.name.Contains("SKINNEDMESH")&&
						    !transformChild.gameObject.name.Contains("GroupPivots")){
							DestroyImmediate(transformChild.gameObject);
						}else{
							if (transformChild.gameObject.name.Contains("default")){
								transformChild.SetParent(meshGroup.transform);
							}
						}
					}
				}
			}
		}
		if (groupPivotsChilds != null) {
			for (int i=1;i<groupPivotsChilds.Length;i++){
				groupPivotsChilds[i].SetParent(this.transform);
				if (groupPivotsChilds[i].childCount==0)DestroyImmediate(groupPivotsChilds[i].gameObject);
			}
		}
		if (groupPivots!=null)DestroyImmediate (groupPivots.gameObject);
		//digital clock second part
		if (digitalClockObject!=null)digitalClockObject.transform.parent = this.gameObject.transform;
		//end of second part
		DestroyImmediate (this);
	}

	public void CleanupScene(){
		OptionsDisplay[] optionsDisplay = FindObjectsOfType (typeof(OptionsDisplay)) as OptionsDisplay[];
		foreach (OptionsDisplay option in optionsDisplay) {
			option.GOCleanup();
		}
	}
	void Update () {
		#if UNITY_EDITOR
		displaySelectedObject = transform.GetComponentsInChildren<DisplaySelectedObject> ();
		displayFrame = transform.GetComponentsInChildren<DisplayFrame>();
		#endif
	}

}
