using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LogInManager : MonoBehaviour {
    SQLConnection sql;
    public InputField UsernameInput;
    public InputField PasswordInput;
    public string loggedInUser = "";

    public static LogInManager instance;

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {
        sql = GetComponent<SQLConnection>();
        Debug.Log("App Started");
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void LogIn()
    {
        StartCoroutine(sql.LoginSql(UsernameInput.text, PasswordInput.text));
    }
    public void SignUp()
    {
        Debug.Log("Not Implemented");
    }
    public string GetLoggedInUser()
    {
        return loggedInUser;
    }
}
