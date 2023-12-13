using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string NpcName = PlayerPrefs.GetString("NpcName");
        string NpcText = PlayerPrefs.GetString("NpcText");
        TextMeshProUGUI NpcNameObj = FindObjectsOfType<TextMeshProUGUI>().First(textObj => { return textObj.name.Contains("NPCNameText"); });
        TextMeshProUGUI NpcDialogObj = FindObjectsOfType<TextMeshProUGUI>().First(textObj => { return textObj.name.Contains("NPCDialogueText"); });
        NpcNameObj.text = NpcName;
        NpcDialogObj.text = NpcText.Replace("{{name}}", NpcName);
    }

    public void TalkOptionButtonClick()
    {

    }

    public void CloseDialogButtonClick()
    {
        string sceneName = "DialogBox";
        SceneManager.UnloadSceneAsync(sceneName);
    }
}
