using UnityEngine;
using TMPro;
using System.Collections;

public class DebugToTMPro : MonoBehaviour
{
    public TextMeshProUGUI debugText;
    private Coroutine clearRoutine;

    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        debugText.text = logString; 

        if (clearRoutine != null)
            StopCoroutine(clearRoutine);

        clearRoutine = StartCoroutine(ClearAfterDelay(0.8f));
    }

    IEnumerator ClearAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        debugText.text = string.Empty;
    }
}