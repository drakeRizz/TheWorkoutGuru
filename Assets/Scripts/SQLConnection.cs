using UnityEngine;
using System.Collections;

public class SQLConnection : MonoBehaviour {

    private string hashCode = "SecretHashcode";
    //  The new connection URL is http://gerardroof.ro/theworkoutguru/Login.php
    public string connectionURL = "http://gerardroof.ro/theworkoutguru/Login.php";
    private string responseString = string.Empty;
    public bool isLoggedIn = false;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public IEnumerator LoginSql(string username ,string password)
    {
        WWWForm form = new WWWForm(); 
        form.AddField("myform_hash", hashCode);
        form.AddField("myform_nick", username);
        //form.AddField("myform_pass", password);
        WWW w = new WWW(connectionURL, form); //here we create a var called 'w' and we sync with our URL and the form
        yield return w; //we wait for the form to check the PHP file, so our app dont just hang
        if (w.error != null)
        {
            Debug.Log(w.error); //if there is an error, tell us
        }
        else {
            responseString = w.text; //here we return the data our PHP told us
            if(responseString.Contains("Logged In")) { 
                isLoggedIn = true;
                Debug.Log("Logged in as " + username);
                GetComponent<LogInManager>().loggedInUser = username;
                Application.LoadLevel("MainScene");
            }
            else
            {
                isLoggedIn = false;
                Debug.Log("Login error :" + responseString);
            }
            w.Dispose(); //clear our form in game
        }
    }
}
