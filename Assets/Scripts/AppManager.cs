using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AppManager : MonoBehaviour {
    //Public variables
    //Sql Things
    [SerializeField]
    private string loggedInUser;

    //App Pages
    public GameObject menuPage;
    public GameObject todayExercisesPage;
    public GameObject yourStatsPage;
    public GameObject achievementsPage;
    public GameObject friendsPage;


    GameObject currentPage;
    GameObject lastPage;
    //others
    public int selectedExercise;
    public int exerciseCoins;
    public int exerciseRepeats;
    public int exerciseDifficulty;
    public string exerciseType;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
        currentPage = menuPage;
        loggedInUser = LogInManager.instance.GetLoggedInUser();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void btnTodayExercises()
    {
        menuPage.GetComponent<Animation>().PlayQueued("HidePage", QueueMode.CompleteOthers);
        todayExercisesPage.SetActive(true);
        todayExercisesPage.GetComponent<Animation>().PlayQueued("ShowPage", QueueMode.CompleteOthers);
        lastPage = currentPage;
        currentPage = todayExercisesPage;

    }

    public void btnYourStatistics()
    {
        menuPage.GetComponent<Animation>().PlayQueued("HidePage", QueueMode.CompleteOthers);
        yourStatsPage.SetActive(true);
        yourStatsPage.GetComponent<Animation>().PlayQueued("ShowPage", QueueMode.CompleteOthers);
        lastPage = currentPage;
        currentPage = yourStatsPage;
    }
    public void btnAchievements()
    {
        menuPage.GetComponent<Animation>().PlayQueued("HidePage", QueueMode.CompleteOthers);
        achievementsPage.SetActive(true);
        achievementsPage.GetComponent<Animation>().PlayQueued("ShowPage", QueueMode.CompleteOthers);
        lastPage = currentPage;
        currentPage = achievementsPage;
    }
    public void btnFriends()
    {
        menuPage.GetComponent<Animation>().PlayQueued("HidePage", QueueMode.CompleteOthers);
        //friendsPage.SetActive(true);
        //friendsPage.GetComponent<Animation>().PlayQueued("ShowPage", QueueMode.CompleteOthers);
        lastPage = currentPage;
        //currentPage = friendsPage;
        currentPage = achievementsPage;
        achievementsPage.SetActive(true);
        achievementsPage.GetComponent<Animation>().PlayQueued("ShowPage", QueueMode.CompleteOthers);
    }
    public void backBtn(){
        if(currentPage == menuPage)
        {
            Application.Quit();
        }
        else
        {
            currentPage.GetComponent<Animation>().PlayQueued("HidePage",QueueMode.CompleteOthers);
            lastPage.SetActive(true);
            lastPage.GetComponent<Animation>().PlayQueued("ShowPage", QueueMode.CompleteOthers);
            currentPage = lastPage;

        }
    }
    void resetScale()
    {

    }
    public void startExercise(int selectedExercise, int exerciseCoins, int exerciseRepeats, int exerciseDifficulty, string exerciseType)
    {
        this.selectedExercise = selectedExercise;
        this.exerciseCoins = exerciseCoins;
        this.exerciseRepeats = exerciseRepeats;
        this.exerciseDifficulty = exerciseDifficulty;
        Application.LoadLevel("ExerciseScene");
        this.exerciseType = exerciseType;
    }
    public string GetLoggedInUser()
    {
        return loggedInUser;
    }
}
