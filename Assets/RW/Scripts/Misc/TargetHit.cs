/*
 * Description: Reports back an objects distance and name from the player. This script should be placed on the Player.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
    [SerializeField] public float distanceInfo;
    public LayerMask mask;
    [SerializeField] public string objectHitName;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit dist;

        if (Physics.Raycast(ray, out dist, 100, mask, QueryTriggerInteraction.Ignore))
        {
            distanceInfo = dist.distance;
            objectHitName = dist.collider.gameObject.name;
            //print("Object Hit: " + objectHitName + "\nObject Distance: " + distanceInfo);
            Debug.DrawLine(ray.origin, dist.point, Color.red);
        } else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.green);
            distanceInfo = 0;
            objectHitName = "Nothing";
        }


    }

    public float getDistanceInfo()
    {
        return distanceInfo;
    }

    public string getObjectHitName()
    {
        return objectHitName;
    }
}
