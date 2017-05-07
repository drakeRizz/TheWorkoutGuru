using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;

/// <summary>
/// <author>Jefferson Reis</author>
/// <explanation>Works only on Android. To test, change the platform to Android.</explanation>
/// </summary>

public class TextToSpeech : MonoBehaviour
{
    public string words = "Hello";

    IEnumerator StartSpeaking()
    {
        // Remove the "spaces" in excess
        Regex rgx = new Regex("\\s+");
        // Replace the "spaces" with "% 20" for the link Can be interpreted
        string result = rgx.Replace(words, "%20");
       
        string url = "https://code.responsivevoice.org/develop/getvoice.php?t=" + result + "&tl=en-US&sv=g2&vn=&rate=1";
        WWW www = new WWW(url);
        yield return www;
        /*foreach(KeyValuePair<string,string> entry in www.responseHeaders)
            Debug.Log(entry.Key + ":" + entry.Value);*/
        audio.clip = www.GetAudioClip(false, false, AudioType.MPEG);
        audio.Play();
    }

    /*void OnGUI()
    {
        words = GUI.TextField(new Rect(Screen.width / 2 - 200 / 2, 10, 200, 30), words);
        if (GUI.Button(new Rect(Screen.width / 2 - 150 / 2, 40, 150, 50), "Speak"))
        {
            StartCoroutine(StartSpeaking());
        }
    }*/
    public void Speak(string words)
    {
        this.words = words;
        StartCoroutine(StartSpeaking());
    }


}