using UnityEngine;
using System.Collections;

public class SQLGetAchievementsData : MonoBehaviour {

    private string hashCode = "SecretHashcode";
    public string connectionURL = "http://gerardroof.ro/theworkoutguru/GetAchievementsData.php";
    public string responseString;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(GetData(LogInManager.instance.GetLoggedInUser()));
    }

    public IEnumerator GetData(string username)
    {
        .//WWWForm form = new WWWForm();
        form.AddField("myform_hash", hashCode);
        form.AddField("myform_nick", username);
        WWW w = new WWW(connectionURL, form); //here we create a var called 'w' and we sync with our URL and the form
        yield return w; //we wait for the form to check the PHP file, so our game dont just hang
        if (w.error != null)
        {
            Debug.Log(w.error); //if there is an error, tell us
        }
        else
        {
            responseString = w.text; //here we return the data our PHP told us
            GetComponent<AchievementsManager>().splitAchievementsData();
            w.Dispose(); //clear our form in game
        } 

    }
}
