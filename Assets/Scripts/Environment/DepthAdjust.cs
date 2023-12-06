using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthAdjust : MonoBehaviour
{
    private GameObject player;
    private BoxCollider2D box;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        if (box) position = new Vector3(
            position.x + box.offset.x * transform.localScale.x,
            position.y + box.offset.y * transform.localScale.y,
            position.z);

        float distance = position.y - player.transform.position.y;

        transform.position = new Vector3(transform.position.x, transform.position.y, 0.1f * distance / 64f);
    }
}
