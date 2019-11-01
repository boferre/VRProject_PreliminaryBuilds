using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class ToggleLaser : MonoBehaviour {
	public SteamVR_Input_Sources handType;
public SteamVR_Behaviour_Pose controllerPose;
public SteamVR_Action_Boolean laserAction;
    public Transform cameraRigTransform;
    public Transform headTransform; // The camera rig's head
    public GameObject laserPrefab; // The laser prefab
   public GameObject laser; // A reference to the spawned laser
    private Transform laserTransform; // The transform component of the laser for ease of use
    private Vector3 hitPoint; // Point where the raycast hits
	private bool laserOn;

	
	// Use this for initialization
	void Start () {
		laser = Instantiate(laserPrefab);
        laserTransform = laser.transform;
		laserOn = false;
		
	}
	
	// Update is called once per frame
	void Update () {
/* 		if (laserAction.GetState(handType)){
			if(laserOn){
			RaycastHit hit;
            // Send out a raycast from the controller
            if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 100))
            {
                hitPoint = hit.point;

                ShowLaser(hit);
  
            }
				laser.SetActive(false);
			}else{
				laser.SetActive(true);
			}
		} */
		RaycastHit hit;
		if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 100))
            {
                hitPoint = hit.point;

                ShowLaser(hit);
  
            }
			
			if(laserAction.GetState(handType)){
				
					laser.SetActive(false);
			}
	}
	    private void ShowLaser(RaycastHit hit)
    {
        laser.SetActive(true); //Show the laser
        laserTransform.position = Vector3.Lerp(controllerPose.transform.position, hitPoint, .5f); // Move laser to the middle between the controller and the position the raycast hit
        laserTransform.LookAt(hitPoint); // Rotate laser facing the hit point
        laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y,
            hit.distance); // Scale laser so it fits exactly between the controller & the hit point
    }
	


}
