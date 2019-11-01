/*
 * Created by: Brandon Orion Ferrell
 * Description: Functions to provide the user with a report on how well they did in the round
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;


public class report
{
    public string Name { get; set; }
    public float predictedTime { get; set; }
    public Stopwatch time { get; set; }
    public bool hit { get; set; }


    public report(string name, float fittsTime, Stopwatch roundTime, bool targetHit)
    {
        Name = name;
        predictedTime = fittsTime;
        time = roundTime;
        hit = targetHit;
    }
    
}



public class CompileReport : MonoBehaviour
{
    public report[] userReport = new report[5];
    public int maxRounds;


    public void initializeReport(string username, float avg, Stopwatch roundTime, int round, bool hit, int roundStop)
    {
        userReport[round-1] = new report(username, avg, roundTime, hit);
        maxRounds = roundStop;
    }


    public string getUserName()
    {
        return userReport[1].Name;
    }


    public string getroundTime(int round)
    {
        int hours = 0;
        int minutes = 0;
        int seconds = 0;

        return "";
    }


    public string printReport()
    {
        // Get accuracy
        int accuracy = 0;
        float avgFittsTime = 0;
        float retrieveTime = 0;
        for(int x = 0; x < 5; x++)
        {
            if (userReport[x].hit)
            {
                accuracy++;
            }
            retrieveTime = userReport[x].predictedTime;
           
            avgFittsTime += retrieveTime;
            retrieveTime = userReport[x].time.ElapsedMilliseconds;
            
        }
        accuracy = accuracy / maxRounds;
        avgFittsTime = avgFittsTime / maxRounds;
        avgFittsTime = (float)Math.Round(avgFittsTime, 3);
        // Save Values to Player Pref
        PlayerPrefs.SetInt("Rounds", maxRounds);
        PlayerPrefs.SetFloat("Accuracy", (accuracy * 100));
        PlayerPrefs.SetFloat("TotalTime", (retrieveTime / 1000));
        PlayerPrefs.SetFloat("AvgTime", ((retrieveTime / 1000) / maxRounds));
        PlayerPrefs.SetString("PredTime", avgFittsTime.ToString());

        string compiledString = "";

        compiledString = "Report of: " + getUserName() + "     Accuracy: " + accuracy + "     Fitts Time Average: " + avgFittsTime;

        return compiledString;
    }
}
