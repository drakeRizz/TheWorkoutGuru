using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountDownTicker : MonoBehaviour {

    int exerciseRepeats;
    int countDown = 0 ;
    public ExerciseManager exManager;
    public TextToSpeech TTS;
	// Use this for initialization
	void Start () {
        exerciseRepeats = exManager.exerciseRepeats;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void startCountDown()
    {
        countDownTick();
    }

    public void countDownTick()
    {
        if (exManager.isExerciseStarted) { 
        animation.PlayQueued("CountDown", QueueMode.CompleteOthers);
        countDown++;
        TTS.Speak(""+countDown);
        GetComponent<Text>().text = "" + countDown;
        if (countDown == exerciseRepeats)
        {
            exManager.OnExerciseFinished();
        }
        }
    }
}
