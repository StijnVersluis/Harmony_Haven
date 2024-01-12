using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeditateScript : MonoBehaviour
{
    public KeyCode InteractKey = KeyCode.E;
    public SceneAsset MeditationScene;
    public TextMeshProUGUI InteractText;
    bool inRange = false;
    GameObject playerCharacter;

    // Start is called before the first frame update
    void Start()
    {
        InteractText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown(InteractKey))
        {
            playerCharacter.transform.position = new Vector3(-16.06f, -0.95f);
            StartMeditation();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InteractText.enabled = true;
        InteractText.text = "Ademhalingsoefeningen\nDruk op " + InteractKey.ToString();
        playerCharacter = collision.gameObject;
        inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        InteractText.enabled = false;
        inRange = false;
        if (SceneManager.GetSceneByName(MeditationScene.name).isLoaded) SceneManager.UnloadSceneAsync(MeditationScene.name);
    }

    void StartMeditation()
    {
        if (!SceneManager.GetSceneByName(MeditationScene.name).isLoaded)
        {
            SceneManager.LoadScene(MeditationScene.name, LoadSceneMode.Additive);
        }
    }
}
