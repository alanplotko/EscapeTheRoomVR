using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(OptionsDisplay))]
public class EditorOptionsDisplay : Editor 
{
	private int rowSize=4;
	private float buttonSize=60;

	public override void OnInspectorGUI()
	{
		OptionsDisplay myTarget = (OptionsDisplay)target;

		if (myTarget != null) {
			if (myTarget.gameObject.activeInHierarchy) {

				if (myTarget.displayFrame != null) {
					for (int i=0; i<myTarget.displayFrame.Length; i++) {
						GUILayout.Label (myTarget.displayFrame [i].name + " Open Value");
						myTarget.blindsOpenValue = GUILayout.HorizontalSlider (myTarget.blindsOpenValue, 0.0f, 1.0f);
						myTarget.displayFrame [i].curAnimationFrame = myTarget.blindsOpenValue;
						EditorUtility.SetDirty (myTarget);
						EditorUtility.SetDirty (myTarget.displayFrame [i]);
					}
				}
				for (int k=0; k < myTarget.displaySelectedObject.Length; k++) {
					if (myTarget.displaySelectedObject[k].ButtonSelectable==true){
						GUILayout.Label (myTarget.displaySelectedObject [k].gameObject.name);
						Texture2D[] texturesToDisplay = ReceiveCurrentTexturePack2 (myTarget.displaySelectedObject [k].gameObject.name, myTarget);
						if (texturesToDisplay != null) {
							GUILayout.BeginVertical ("Box", GUILayout.Width (buttonSize * rowSize + (rowSize * 5)), GUILayout.Height (buttonSize * Mathf.Ceil (myTarget.displaySelectedObject [k].displayOptions.Length / rowSize)));
							for (int i=0; i<myTarget.displaySelectedObject[k].displayOptions.Length; i+=0) {
								if (texturesToDisplay == null)
									break;
								if (texturesToDisplay.Length == 0)
									break;
								GUILayout.BeginHorizontal ();
								for (int j=0; j < rowSize && i<myTarget.displaySelectedObject[k].displayOptions.Length; j++) {
									if (GUILayout.Button (texturesToDisplay [i], GUILayout.Width (buttonSize), GUILayout.Height (buttonSize))) {
										myTarget.displaySelectedObject [k].TurnSelectedWithButton (i);
										EditorUtility.SetDirty (myTarget.displaySelectedObject [k]);
									}
									i++;
								}
								GUILayout.EndHorizontal ();
							}
							GUILayout.EndVertical ();
						}
					}
				}
				//DrawDefaultInspector ();
				if (GUILayout.Button ("Done!",GUILayout.Height(50.0f))) {
					myTarget.GOCleanup ();
				}
				if (GUILayout.Button ("Cleanup All Scene",GUILayout.Height(50.0f))) {
					if (EditorUtility.DisplayDialog("Clean Up Scene?","You wil no longer be able to select options from Furniture Objects you have already created.","Clean Up Scene","Cancel")){
						myTarget.CleanupScene ();
					}
				}

			}
		}
	}
	
	public Texture2D[] ReceiveCurrentTexturePack2(string objectName, OptionsDisplay myTarget){
		if (objectName.Contains("DoorHandles Select"))return myTarget.GlobalOptionsDisplaySaveVar.doorHandlesModels;
		if (objectName.Contains("Mod Type select"))return myTarget.GlobalOptionsDisplaySaveVar.modType;
		if (objectName.Contains("material select"))return myTarget.GlobalOptionsDisplaySaveVar.materialType;
		if (objectName.Contains("Shine Select"))return myTarget.GlobalOptionsDisplaySaveVar.materialType;
		if (objectName.Contains("Stickers select"))return myTarget.GlobalOptionsDisplaySaveVar.materialType;
		if (objectName.Contains("Light Switch"))return myTarget.GlobalOptionsDisplaySaveVar.lightSwitcher;
		if (objectName.Contains("Turn Light"))return myTarget.GlobalOptionsDisplaySaveVar.lightSwitcher;
		if (objectName.Contains("Bulb Color Select"))return myTarget.GlobalOptionsDisplaySaveVar.bulbColor;
		if (objectName.Contains("Screen Select"))return myTarget.GlobalOptionsDisplaySaveVar.screenModels;
		if (objectName.Contains("Screen Type1 Select"))return myTarget.GlobalOptionsDisplaySaveVar.type1ScreenModels;
		if (objectName.Contains("Screen Type2 Select"))return myTarget.GlobalOptionsDisplaySaveVar.type2ScreenModels;
		if (objectName.Contains("Floor Lamp Models"))return myTarget.GlobalOptionsDisplaySaveVar.floorLampModels;
		if (objectName.Contains("Simple Roof Lamp Models"))return myTarget.GlobalOptionsDisplaySaveVar.simpleRoofLampModels;
		if (objectName.Contains("Table Lamp Models"))return myTarget.GlobalOptionsDisplaySaveVar.tableLampModels;
		if (objectName.Contains("Wall Lamp Models"))return myTarget.GlobalOptionsDisplaySaveVar.wallLampModels;
		if (objectName.Contains("Lamp Table Models"))return myTarget.GlobalOptionsDisplaySaveVar.lampTableModels;
		if (objectName.Contains("Small Table Models"))return myTarget.GlobalOptionsDisplaySaveVar.smallTableModels;
		if (objectName.Contains("Area_S"))return myTarget.GlobalOptionsDisplaySaveVar.reverseTexture;
		if (objectName.Contains("Wall Models"))return myTarget.GlobalOptionsDisplaySaveVar.wallModels;
		if (objectName.Contains("Floor Tile Select"))return myTarget.GlobalOptionsDisplaySaveVar.floorTile;



		if (objectName.Contains("LED Atlas"))return myTarget.GlobalOptionsDisplaySaveVar.LEDTextures;
		if (objectName.Contains("Wood Atlas"))return myTarget.GlobalOptionsDisplaySaveVar.woodTextures;
		if (objectName.Contains("Metal Atlas"))return myTarget.GlobalOptionsDisplaySaveVar.metalTextures;
		if (objectName.Contains("Marble Atlas"))return myTarget.GlobalOptionsDisplaySaveVar.marbleTextures;
		if (objectName.Contains("Plastic Atlas"))return myTarget.GlobalOptionsDisplaySaveVar.plasticTextures;
		if (objectName.Contains("Cloth Atlas"))return myTarget.GlobalOptionsDisplaySaveVar.clothTextures;
		if (objectName.Contains("Quarry Atlas"))return myTarget.GlobalOptionsDisplaySaveVar.quarryTextures;
		if (objectName.Contains("Leather Atlas"))return myTarget.GlobalOptionsDisplaySaveVar.leatherTextures;
		if (objectName.Contains("Granite Atlas"))return myTarget.GlobalOptionsDisplaySaveVar.graniteTextures;
		if (objectName.Contains("Lamp Screen Atlas"))return myTarget.GlobalOptionsDisplaySaveVar.lampTextures;
		if (objectName.Contains("Rug Atlas"))return myTarget.GlobalOptionsDisplaySaveVar.rugTextures;
		if (objectName.Contains("Curtain Atlas"))return myTarget.GlobalOptionsDisplaySaveVar.curtainsTextures;
		if (objectName.Contains("Floor Atlas"))return myTarget.GlobalOptionsDisplaySaveVar.floorTextures;
		if (objectName.Contains("Wall Atlas"))return myTarget.GlobalOptionsDisplaySaveVar.wallsTextures;
		if (objectName.Contains("Blinds Atlas"))return myTarget.GlobalOptionsDisplaySaveVar.blindsTextures;
		if (objectName.Contains("Glass Atlas"))return myTarget.GlobalOptionsDisplaySaveVar.glassTextures;
		if (objectName.Contains("PictureLong Atlas"))return myTarget.GlobalOptionsDisplaySaveVar.longPictures;
		if (objectName.Contains("PictureTall Atlas"))return myTarget.GlobalOptionsDisplaySaveVar.tallPictures;
		if (objectName.Contains("PictureQuad Atlas"))return myTarget.GlobalOptionsDisplaySaveVar.quadPictures;
		if (objectName.Contains("Game Atlas"))return myTarget.GlobalOptionsDisplaySaveVar.gamePictures;

		return null;
	}
}