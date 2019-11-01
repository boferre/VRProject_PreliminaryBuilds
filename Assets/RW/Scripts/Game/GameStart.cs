using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.SceneManagement;

/*
 * Description: Controls the game. This varies from the round and timer, to the firing of the player, and the handling of information.
 * Should be placed on a gameobject within the scene.
 * Needs to interact with the GUI
 */

public class GameStart : MonoBehaviour {


    private bool targetHit;


    [SerializeField] public int maxRounds = 5;
    [SerializeField] public int round;
    [SerializeField] public Stopwatch roundTime;
    [SerializeField] public string playersName;

    public FitsLaw fittsController;
    public CompileReport report;


    void Start () {
        fittsController = new FitsLaw();
        report = new CompileReport();
        round = 0;
        targetHit = false;
        roundTime = new Stopwatch();
        playersName = "Tester";

        print("Game Initialized");
        StartCoroutine(GameController());

        
    }


    IEnumerator GameController()
    {
        // The game has been started
        print("Welcome to The Fitts.");

        while (round < maxRounds)
        {

            // Wait for user to start the round
            print("To start the round, press space");
            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }
            print("Round Started!");
            gameStart(round);

            // Wait for the user to fire
            print("Waiting for user to fire at target");
            while (!Input.GetMouseButtonDown(0))
            {
                yield return null;
            }
            print("User has fired!");
            fired();
            print("Round " + round + " Ending.");

        }

        // Game is over. 
        print("Game has ended!");
        roundTime.Stop();
        gameEnd();
    }


    // Initializes the start of the round.
    void gameStart(int currRound)
    {
        roundTime.Start();
        round++;
        print("Round " + round + " has started");
    }


    // Controls what happens when the game ends in terms of a report screen.
    void gameEnd()
    {
        print("Printing Report");
        print(report.printReport());
        SceneManager.LoadScene(2);
    }


    // Controls when a user has fired. Gets the target information and calculates fitts law.
    void fired()
    {
        roundTime.Stop();
        GameObject target = GameObject.Find("/Player/Controller (right)");
        TargetHit targetInfo = target.GetComponent<TargetHit>();

        float calcFittsTime = 0.0f;
        float targetDistance = targetInfo.getDistanceInfo();
        string targetName = targetInfo.getObjectHitName();

        print("PLAYER HAS FIRED!");
        print("Player has hit: " + targetName);
        print("Object distance: " + targetDistance);
        print("Calculating Fitts time");
        calcFittsTime = fittsController.calcFittsLaw(targetDistance, targetName);
        print("Fitts time calculated in seconds: " + calcFittsTime);

        if (targetName != "Nothing")
        {
            print("Target Hit!");
            targetHit = true; 
        }
        else
        {
            print("Target Missed!");
            targetHit = false;
        }

        report.initializeReport(playersName, calcFittsTime, roundTime, round, targetHit, maxRounds);
    }

}
