using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
        canvas.planeDistance = 5f;
    }
}
