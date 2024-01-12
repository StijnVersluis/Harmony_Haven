using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeditationController : MonoBehaviour
{
    public SceneAsset MeditationScene;
    public void StopMeditation()
    {
        if (SceneManager.GetSceneByName(MeditationScene.name).isLoaded)
        {
            SceneManager.UnloadSceneAsync(MeditationScene.name);
        }
    }
}
