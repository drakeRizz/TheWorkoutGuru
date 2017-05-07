using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AchievementScript : MonoBehaviour {
    // The script defining a simple achievement
    public Text achievementTitle; 
    public Text achievementDescription;
    public Text achievementCoins;
    public Button claimButton;
    private bool isClaimed = false;
    public Image whiteCircle;

	// Use this for initialization
	void Start () {
	//Removed unnecesary comments
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
