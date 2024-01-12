using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string NpcName = PlayerPrefs.GetString("NpcName");
        TextMeshProUGUI NpcNameObj = FindObjectsOfType<TextMeshProUGUI>().First(textObj => { return textObj.name == "NPCNameText"; });
        NpcNameObj.text = NpcName;
    }
}
