using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExerciseManager : MonoBehaviour
{
    //UI
    public Button btnStart;
    public Button btnFinish;
    public Text txtTicks;
    public CountDownTicker ticker;
    // 0 for pushups , 1 for abs , 2 for another exercise , etc...
    public int selectedExercise = 0;
    public ExerciseAnimationScript exAnimationScript;
    public int exerciseRepeats = 30;
    public int exerciseDifficulty = 0;
    public int exerciseCoins = 0;
    private int exerciseExperience;
    private int groupCount;
    public bool isExerciseStarted=false;
    public Text exerciseName;
    public string exerciseType;
    public ExerciseManager EM;
    public AppManager AM;
    // Use this for initialization
    // Datebase
    private string hashCode = "SecretHashcode";
    public string connectionURL = "http://gerardroof.ro/theworkoutguru/UpdateStatsData.php";

    void Start()
    {
        AM = GameObject.Find("App Manager").GetComponent<AppManager>();
        exerciseType = AM.exerciseType;
        selectedExercise = AM.selectedExercise;
        exerciseRepeats = AM.exerciseRepeats;
        exerciseCoins = AM.exerciseCoins;
        exerciseDifficulty = AM.exerciseDifficulty;
        txtTicks.text = exerciseRepeats + " Repeats";
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartExercise()
    {
        isExerciseStarted = true;
        btnStart.gameObject.SetActive(false);
        ticker.startCountDown();
    }

    public void OnExerciseFinished()
    {
        isExerciseStarted = false;
        ticker.TTS.Speak("Good JOB !");
        btnFinish.gameObject.SetActive(true);
        //Set new coins

        //updateDatebase();
        updateDatebase();
    }

    public void updateDatebase()
    {
        GameObject UM = GameObject.Find("UserManager");
        UserManager US = UM.GetComponent<UserManager>();
        US.coins = US.coins + exerciseCoins;
        US.experience = US.experience + exerciseExperience;
        WWWForm form = new WWWForm();
        form.AddField("myform_hash", hashCode);
        form.AddField("myform_nick", LogInManager.instance.GetLoggedInUser());
        form.AddField("myform_coins", US.coins);
        if (exerciseType == "group_chest")
            US.group_chest = US.group_chest + 1;
        else if (exerciseType == "group_abs")
            US.group_abs = US.group_abs + 1;
        form.AddField("myform_group_chest", US.group_chest);
        form.AddField("myform_group_abs", US.group_abs);
        form.AddField("myform_experience", US.experience);
        form.AddField("myform_level", US.level);
        WWW w = new WWW(connectionURL, form);
    }

    public void ReturnToExercisesPage()
    {
        Application.LoadLevel(0);
    }
    public void backBtn()
    {
        Application.LoadLevel("MainScene");
    }
}
