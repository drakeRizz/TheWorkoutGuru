using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExerciseAnim : MonoBehaviour {

    //public variables
    public ExerciseAnimationScript eas;
    public Sprite[] frames;
    public float framesPerSecond= 2.0f;
    private bool isPlaying;
    public string exerciseName;
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (isPlaying) { 
            int index;
            index = (int) ( Time.time * framesPerSecond) % frames.Length;
            eas.GetComponent<Image>().sprite =  frames[index];
        }
    }

    public void Play()
    {
        isPlaying = true;
    }
    public void Stop()
    {
        isPlaying = false;
    }
}
