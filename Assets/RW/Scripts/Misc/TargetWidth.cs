using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetWidth : MonoBehaviour
{
    public float width;

    private void Start()
    {
        Vector3 size;
        MeshRenderer renderer;

        renderer = GetComponent<MeshRenderer>();
        size = renderer.bounds.size;
        width = size.x;
    }
}
