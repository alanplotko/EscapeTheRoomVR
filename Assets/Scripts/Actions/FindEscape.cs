using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindEscape : MonoBehaviour {
    // Play audio sequence and show congratulatory messsage for escaping room
    public void Escape() {
        DigitalClock clock = GameObject.FindGameObjectWithTag ("digitalLED").GetComponent<DigitalClock>();
        AudioSource breakEffect = GameObject.FindWithTag("mirror").GetComponent<AudioSource>();
        breakEffect.Play();
        GameObject.Destroy(GameObject.FindGameObjectWithTag ("reflectionProbe"));
        string form = (clock.score == 1) ? "minute" : "minutes";
        gameObject.GetComponent<Usable>().Inspect(
            string.Format("You've successfully escaped in {0} {1}!", clock.score, form)
        );
        GameObject.FindWithTag("mirror").GetComponent<Usable>().enabled = false;
        GameObject.FindWithTag("mirror").GetComponent<Collectable>().enabled = false;
        GameObject.FindWithTag("mirror").GetComponent<Collider>().enabled = false;
        AudioSource bgAudio = GameObject.Find("Background Music").GetComponent<AudioSource>();
        bgAudio.Stop();
        StopCoroutine("PlayTime");
        if (clock.pointFlicker && clock.secondsDCV == null) {
            StopCoroutine("PlayPointFlicker");
        }
    }
}
