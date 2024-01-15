using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupController2D : MonoBehaviour
{
    public SceneAsset BookScene;
    public KeyCode InteractKey = KeyCode.E;

    private bool inRange = false;

    private void Start()
    {
    }

    private void Update()
    {
        if (inRange && Input.GetKeyDown(InteractKey))
        {
            ShowHidePopup();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
            SceneManager.UnloadSceneAsync(BookScene.name);
        }
    }

    private void ShowHidePopup()
    {
        if (!SceneManager.GetSceneByName(BookScene.name).isLoaded)
        {
            SceneManager.LoadScene(BookScene.name, LoadSceneMode.Additive);
        } else
        {
            SceneManager.UnloadSceneAsync(BookScene.name);
        }
    }
}
