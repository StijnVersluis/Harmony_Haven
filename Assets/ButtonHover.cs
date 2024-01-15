using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour
{
    Color colourChange;

    // Start is called before the first frame update
    void Start()
    {
        var buttonColor = transform.GetComponent<Button>().image.color;
        colourChange = new Color(buttonColor.r, buttonColor.g, buttonColor.b, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MouseOver()
    {
        colourChange.a = 0.1f;
        transform.GetComponent<Button>().image.color = colourChange;
    }

    public void MouseExit()
    {
        colourChange.a = 0f;
        transform.GetComponent<Button>().image.color = colourChange;
    }
}
