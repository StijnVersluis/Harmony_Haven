using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour
{
    public SpriteRenderer fgRenderer;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            fgRenderer.enabled = false;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            fgRenderer.enabled = true;
        }
    }
}
