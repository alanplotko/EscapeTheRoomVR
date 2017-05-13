using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class DisplayFrame : MonoBehaviour {
	public DisplaySelectedObject displaySelectdObjects;
	public AnimationClip tarAnimation;
	[Range(0.0f, 1.0f)]
	public float curAnimationFrame=0;
	private int lastFrameInt = 0;
	private int curFrameInt=0;
	public GameObject[] blindsGameObjects;
	// Use this for initialization
	void OnEnable () {
		displaySelectdObjects=transform.GetComponent <DisplaySelectedObject>();
	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_EDITOR
		if (tarAnimation!=null){
			tarAnimation.SampleAnimation(displaySelectdObjects.displayOptions[displaySelectdObjects.currentDisplay].gameObject,curAnimationFrame*tarAnimation.length);
		}
		else{ 
			if (blindsGameObjects!=null){
				curFrameInt = Mathf.RoundToInt(curAnimationFrame*(blindsGameObjects.Length-1));
				if (curFrameInt!=lastFrameInt){
					blindsGameObjects[curFrameInt].SetActive(true);
					blindsGameObjects[lastFrameInt].SetActive(false);
					lastFrameInt=curFrameInt;
				}
			}
		}
		#endif
	}
}
