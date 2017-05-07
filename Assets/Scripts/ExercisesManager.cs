using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExercisesManager : MonoBehaviour {
    private SQLGetExercisesData sql;
    public GameObject exercisePanel;
    public GameObject exerciseItemPrefab;
    private string hashCode = "SecretHashcode";
    public string connectionURL = "http://gerardroof.ro/theworkoutguru/GetExercisesData.php";
    public string responseString;
    public AudioClip onClickSound;
    public AppManager AM;
    // Use this for initialization
    void Start()
    {
      //  DontDestroyOnLoad(this);
        sql = GetComponent<SQLGetExercisesData>();
        AudioSource audio = GetComponent<AudioSource>();
        AM = GameObject.Find("App Manager").GetComponent<AppManager>();
        audio.PlayOneShot(onClickSound);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void splitExercisesData()
    {

        string[] exercises = sql.responseString.Split('#');
        for (int i = 0; i < exercises.Length - 1; i++)
        {
            string[] exercise = exercises[i].Split('|');
            int exercise_id = int.Parse(exercise[0]);
            string exercise_title = exercise[1];
            string exercise_description = exercise[2];
            string exercise_category = exercise[3];
            int exercise_difficulty = int.Parse(exercise[4]);
            int exercise_repeats = int.Parse(exercise[5]);
            int exercise_coins = int.Parse(exercise[6]);
            GameObject exerciseItem = (GameObject)Instantiate(exerciseItemPrefab, exerciseItemPrefab.transform.position, exerciseItemPrefab.transform.rotation);
            ExerciseScript ES = exerciseItem.GetComponent<ExerciseScript>();
            exerciseItem.transform.SetParent(exercisePanel.transform, false);
            ES.exercise_repeats = exercise_repeats;
            ES.exercise_title.text = exercise_title;
            ES.exercise_coins.text = exercise_description;
            ES.exercise_coins.text = "You get " + exercise_coins + " coins !";

            ES.exercise_start_button.onClick.AddListener(delegate { AM.startExercise(exercise_id-1,exercise_coins,exercise_repeats,exercise_difficulty, exercise_category); });
        }


    }

}
