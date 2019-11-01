using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObject : MonoBehaviour
{

    public Vector3 size;

    // Start is called before the first frame update
    void Start()
    {
        size = GetComponent<Collider>().bounds.size;
        Debug.Log("Object Size of " + size);
    }

}
