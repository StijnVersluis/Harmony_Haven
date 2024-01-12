using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class MeditationScript : MonoBehaviour
{
    public TextMeshProUGUI visualText;
    public Button startScalingButton;
    bool startedScaling = false;

    [Tooltip("Breath in, in seconds")]
    public float scaleUpDuration = 3.5f; // Duration for scaling up

    [Tooltip("Breath out, in seconds")]
    public float scaleDownDuration = 4f; // Duration for scaling down

    [Tooltip("Hold breath in, in seconds")]
    public float waitAfterUpDuration = 1f; // Duration to wait between scaling up and scaling down

    [Tooltip("Hold breath out, in seconds")]
    public float waitAfterDownDuration = 1f; // Duration to wait between scaling up and scaling down

    [Tooltip("The scale of the visual")]
    public float scaleUpDown = 2f;

    [Tooltip("The rotation of the visual")]
    public float rotationPercent = 90f;

    private bool isScaling = false;

    private Quaternion initialRotation; // Store the initial rotation
    private Quaternion targetRotation; // Store the target rotation

    // Start is called before the first frame update
    void Start()
    {
        initialRotation = transform.rotation; // Store the initial rotation at the start
        StartCoroutine(ScaleSequence());
    }

    IEnumerator ScaleSequence()
    {
        while (true)
        {
            if (startedScaling)
            {
                yield return StartCoroutine(ScaleUp());
                yield return StartCoroutine(PauseScaling(waitAfterUpDuration));
                yield return StartCoroutine(ScaleDown());
                yield return StartCoroutine(PauseScaling(waitAfterDownDuration));
            }
            else
            {
                yield return new WaitForSeconds(1f);
            }
        }
    }
    IEnumerator PauseScaling(float pauseDuration)
    {
        float timer = 0f;
        while (timer < pauseDuration)
        {
            SetVisualText(Math.Round((pauseDuration - timer)).ToString() + " sec vasthouden");
            timer += UnityEngine.Time.deltaTime;
            yield return null;
        }
    }

    void SetVisualText(string textToDisplay)
    {
        visualText.text = textToDisplay;
    }

    IEnumerator ScaleUp()
    {
        float timer = 0f;
        Vector3 initialScale = transform.localScale;
        Vector3 targetScale = initialScale * scaleUpDown;
        Quaternion initialRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, rotationPercent);


        isScaling = true;

        while (timer < scaleUpDuration)
        {
            SetVisualText(Math.Round((scaleUpDuration - timer)).ToString() + " sec inademen");
            float scaleFactor = timer / scaleUpDuration;
            transform.localScale = Vector3.Lerp(initialScale, targetScale, scaleFactor);
            transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, scaleFactor);
            timer += UnityEngine.Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
        transform.rotation = targetRotation;
        isScaling = false;
        SetVisualText(waitAfterUpDuration + " sec vast houden");
    }

    IEnumerator ScaleDown()
    {
        float timer = 0f;
        Vector3 initialScale = transform.localScale;
        Vector3 targetScale = initialScale / scaleUpDown;
        Quaternion initialRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, 0f);

        isScaling = true;

        while (timer < scaleDownDuration)
        {
            SetVisualText(Math.Round((scaleDownDuration - timer)).ToString() + " sec uitademen");
            float scaleFactor = timer / scaleDownDuration;
            transform.localScale = Vector3.Lerp(initialScale, targetScale, scaleFactor);
            transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, scaleFactor);
            timer += UnityEngine.Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
        transform.rotation = targetRotation;
        isScaling = false;
        SetVisualText(waitAfterDownDuration + " sec vast houden");
    }

    public void StartScaling()
    {
        var buttonText = startScalingButton.GetComponentInChildren<TextMeshProUGUI>();
        if (startedScaling)
        {
            startedScaling = false;
            buttonText.text = "Start oefening";
        }
        else
        {
            startedScaling = true;
            buttonText.text = "Beëindig oefening";
        }
    }
}
