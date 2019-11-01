/*
 * Created by: Brandon Orion Ferrell
 * Description: Functions used to calculate Fitt's Law. This class should be created at the start of any round.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
 * Description: Fitts Law calculator. Does not need to be placed anywhere in the scene.
 */

public class FitsLaw : MonoBehaviour
{

    public float calcFittsLaw(float targetDistance, string target)
    {
        float fittsTime = 0.0f;

        float slope = determineObjectSlope();
        float distance = targetDistance;
        float width = determineObjectWidth(target);

        // T (Time) = a + b log_2 (2(Distance)/(Width)
       fittsTime = slope * ((float)Math.Log(2 * distance/width, 2));

        return fittsTime;
    }

    // Gets the the target objects width. Needs TargetWidth script to be attached to the target object to work.
    private float determineObjectWidth(string target)
    {
        GameObject targ = GameObject.Find("/Objects/" + target);
        float width = targ.GetComponent<TargetWidth>().width;
        
        return width;

    }


    private float determineObjectSlope()
    {
        return 1.0f;
    }

}
