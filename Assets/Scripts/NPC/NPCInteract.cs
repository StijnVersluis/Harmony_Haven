using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCInteract : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E;
    public SceneAsset DialogBoxScene;

    public string NPCName;

    bool inRangeOfNPC = false;
    GameObject speachBubble;
    // Start is called before the first frame update
    void Start()
    {
        speachBubble = gameObject.transform.Find("SpeachBubbleDots").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (inRangeOfNPC && Input.GetKeyDown(interactKey)) HandleNPCInteraction();
    }

    void HandleNPCInteraction()
    {
        if (!SceneManager.GetSceneByName(DialogBoxScene.name).isLoaded)
        {
            PlayerPrefs.SetString("NpcName", NPCName);
            SceneManager.LoadScene(DialogBoxScene.name, LoadSceneMode.Additive);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        speachBubble.SetActive(true);
        if (collision.gameObject.layer == 3) inRangeOfNPC = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3) inRangeOfNPC = false;
        if (SceneManager.GetSceneByName(DialogBoxScene.name).isLoaded) SceneManager.UnloadSceneAsync(DialogBoxScene.name);
        speachBubble.SetActive(false);
    }
}
