using UnityEngine;
using System.Collections;

public class ExerciseAnimationScript : MonoBehaviour {
    public ExerciseManager exManager;
    public ExerciseAnim[] animations;
    public int selectedAnimation;
	// Use this for initialization
	void Start () {
        selectedAnimation = exManager.selectedExercise;
        animations[selectedAnimation].Play();
        exManager.exerciseName.text = animations[selectedAnimation].exerciseName;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
