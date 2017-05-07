using UnityEngine;
using System.Collections;

public class PageScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void disablePage()
    {
        gameObject.SetActive(false);
    }
    public void enablePage()
    {
        gameObject.SetActive(true);
    }

}
