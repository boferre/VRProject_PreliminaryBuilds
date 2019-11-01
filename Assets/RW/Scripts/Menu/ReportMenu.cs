using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReportMenu : MonoBehaviour
{
    public int Rounds;
    public float totalTime;
    public float accuracy;
    public float avgTime;
    public string predTime;


    private void Start()
    {
        loadStats();
        setReportScreen();
    }


    private void loadStats()
    {
       Rounds = PlayerPrefs.GetInt("Rounds");
       totalTime = PlayerPrefs.GetFloat("TotalTime");
       accuracy = PlayerPrefs.GetFloat("Accuracy");
       avgTime = PlayerPrefs.GetFloat("AvgTime");
       predTime = PlayerPrefs.GetString("PredTime");
    }


    private void setReportScreen()
    {
        GameObject round_Object = GameObject.Find("/ReportScreen/TextCont/Round");
        GameObject accuracy_Object = GameObject.Find("/ReportScreen/TextCont/Accuracy");
        GameObject time_Text = GameObject.Find("/ReportScreen/TextCont/Time");
        GameObject avgTime_Text = GameObject.Find("/ReportScreen/TextCont/AverageTime");
        GameObject predTime_Text = GameObject.Find("/ReportScreen/TextCont/PredictedTime");

        round_Object.GetComponent<UnityEngine.UI.Text>().text = "Rounds: " + Rounds;
        time_Text.GetComponent<UnityEngine.UI.Text>().text = "Time: " + totalTime;
        accuracy_Object.GetComponent<UnityEngine.UI.Text>().text = "Accuracy: " + accuracy;
        avgTime_Text.GetComponent<UnityEngine.UI.Text>().text = "Average Time: " + avgTime;
        predTime_Text.GetComponent<UnityEngine.UI.Text>().text = "Predicted Time: " + predTime + " seconds";
    }


    public void retryButton()
    {
        print("Player chose to retry");
        SceneManager.LoadScene(1);
    }


    public void QuitButton()
    {
        print("Player chose to quit");
        SceneManager.LoadScene(0);
        UnityEngine.Debug.Break();
    }
}
