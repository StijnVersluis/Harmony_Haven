using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthAdjust : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < player.transform.position.y) 
            transform.position = new Vector3(transform.position.x, transform.position.y, -0.1f);
        else 
            transform.position = new Vector3(transform.position.x, transform.position.y, 0.1f);
    }
}
