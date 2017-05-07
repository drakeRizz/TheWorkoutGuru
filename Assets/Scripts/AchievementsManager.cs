using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class AchievementsManager : MonoBehaviour {
    private SQLGetAchievementsData sql;
    public GameObject achievementsPanel;
    public GameObject achievementItemPrefab;
    private string hashCode = "SecretHashcode";
    public string connectionURL = "http://gerardroof.ro/theworkoutguru/GetAchievementsData.php";
    public string responseString;
    public Text coinsText;
    public AudioClip onClickSound;

    // Use this for initialization
    void Start () {
        sql = GetComponent<SQLGetAchievementsData>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    
    public void claimCoins(int coins, string username, int achievement_id, int user_id,AchievementScript AS)
    {
        WWWForm form = new WWWForm();
        form.AddField("myform_hash", hashCode);
        form.AddField("myform_nick", username);
        form.AddField("myform_coins", coins);
        form.AddField("myform_achievement_id", achievement_id);
        form.AddField("myform_user_id", user_id);
        WWW w = new WWW(connectionURL, form);

        //audio
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(onClickSound);

        //update hud
        AS.claimButton.gameObject.SetActive(false);
        AS.claimButton.transform.localScale = new Vector3(0, 0, 0);
        AS.GetComponent<Image>().color = Color.grey;
        int oldCoins = int.Parse(coinsText.text);
        int newCoins = oldCoins + coins;
        coinsText.text = "" + newCoins;
    }

    public void splitAchievementsData()
    {
        int user_id=0;
        string[] achievements = sql.responseString.Split('&');
        string[] unlockedAchievements = achievements[0].Split('#');
        for(int i = 0; i < unlockedAchievements.Length-1; i++)
        {
            string[] achievement = unlockedAchievements[i].Split('|');
            int achievement_id = int.Parse(achievement[0]);
            string achievement_title = achievement[1];
            string achievement_details = achievement[2];
            int achievement_coins = int.Parse(achievement[3]);
            int achievemenetClaimed = int.Parse(achievement[4]);
            user_id = int.Parse(achievement[5]);
            bool achievement_claimed;
            if (achievemenetClaimed == 1)
                achievement_claimed = true;
            else achievement_claimed = false;

            GameObject achievementItem = (GameObject)Instantiate(achievementItemPrefab, achievementItemPrefab.transform.position, achievementItemPrefab.transform.rotation);
            AchievementScript AS = achievementItem.GetComponent<AchievementScript>();
            AS.achievementTitle.text = achievement_title;
            AS.achievementDescription.text = achievement_details;
            AS.achievementCoins.text = achievement_coins + " coins";

            if (achievement_claimed)
            {
                AS.claimButton.gameObject.SetActive(false);
                AS.claimButton.transform.localScale = new Vector3(0, 0, 0);
                AS.GetComponent<Image>().color = Color.grey;
            }
            else
            {
                AS.claimButton.onClick.AddListener(delegate { claimCoins(achievement_coins, LogInManager.instance.GetLoggedInUser(), achievement_id, user_id, AS); });
            }
            
            achievementItem.transform.SetParent(achievementsPanel.transform, false);


            
        }
        string[] lockedAchievements = achievements[1].Split('#');
        for(int i = 1; i < lockedAchievements.Length-1; i++)
        {
            string[] lockedAchievement = lockedAchievements[i].Split('|');
            int achievement_id = int.Parse(lockedAchievement[0]);
            string achievement_title = lockedAchievement[1];
            string achievement_details = lockedAchievement[2];
            int achievement_coins = int.Parse(lockedAchievement[3]);
            GameObject achievementItem = (GameObject)Instantiate(achievementItemPrefab, achievementItemPrefab.transform.position, achievementItemPrefab.transform.rotation);
            AchievementScript AS = achievementItem.GetComponent<AchievementScript>();
            AS.achievementTitle.text = achievement_title;
            AS.achievementDescription.text = achievement_details;
            AS.achievementCoins.text = achievement_coins + " coins";

            //opacitate culori
            Color achievement_background = Color.grey;
            achievement_background.a -= 0.6f;
            Color button_background = Color.yellow;
            button_background.a = 0.6f;
            Color whiteCircle_background = Color.white;
            whiteCircle_background.a = 0.6f;

            AS.whiteCircle.GetComponent<Image>().color = whiteCircle_background;
            AS.claimButton.GetComponent<Image>().color = button_background;
            AS.GetComponent<Image>().color = achievement_background;
            
            achievementItem.transform.SetParent(achievementsPanel.transform, false);
        }
        
        
    }
}
