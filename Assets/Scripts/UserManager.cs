using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UserManager : MonoBehaviour
{
    private SQLGetUserData sql;
    //Public values
    public int level;
    public int experience;
    public int coins;
    public string register_date;
    public int exercises_count;
    public int group_neck;
    public int group_traps;
    public int group_shoulders;
    public int group_chest;
    public int group_biceps;
    public int group_forearm;
    public int group_abs;
    public int group_quads;
    public int group_calves;
    public int group_back;

    //HUD things;
    public Slider levelBar;
    public Text coinsText;

	// Use this for initialization
	void Start () {
        sql = GetComponent<SQLGetUserData>();
        DontDestroyOnLoad(this);
    }
	
	// Update is called once per frame
	void Update () {
	
	}


    public void splitUserData()
    {
        string[] array = sql.responseString.Split('|');
        level = int.Parse(array[0]);
        experience = int.Parse(array[1]);
        coins = int.Parse(array[2]);
        register_date = array[3];
        exercises_count = int.Parse(array[4]);
        group_neck = int.Parse(array[5]);
        group_traps = int.Parse(array[6]);
        group_shoulders = int.Parse(array[7]);
        group_chest = int.Parse(array[8]);
        group_biceps = int.Parse(array[9]);
        group_forearm = int.Parse(array[10]);
        group_abs = int.Parse(array[11]);
        group_quads = int.Parse(array[12]);
        group_calves = int.Parse(array[13]);
        group_back = int.Parse(array[14]);
        updateHUD();
    }
    void updateHUD()
    {
        levelBar.GetComponentInChildren<Text>().text = "Level : " + level;
        coinsText.text = "" + coins;
        
    }
}
