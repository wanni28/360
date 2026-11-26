using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazeDoorSelector : MonoBehaviour
{
    public float gazeDistance = 10f;
    public float dwellTime = 3f;
    public Image progressBar; // Filled, Horizontal

    private GazeTarget gazed; // looked at right now
    private GazeTarget lastUsed; // must look away first
    private float timer;

    void Update()
    {
        GazeTarget target = null;
        if (Physics.Raycast(transform.position, transform.forward,
            out RaycastHit hit, gazeDistance))
            target = hit.collider.GetComponent<GazeTarget>();

        if (target != lastUsed) lastUsed = null; // looked away

        if (lastUsed != null) target = null; // still staring

        if (target != gazed)
        {
            if (gazed != null) gazed.SetHighlighted(false);
            gazed = target;
            if (gazed != null) gazed.SetHighlighted(true);
            timer = 0f;
        }

        float fill = gazed == null ? 0f : timer / dwellTime;
        SetBar(fill, gazed != null);
        if (gazed == null) return;

        timer += Time.deltaTime;
        if (timer < dwellTime) return;

        gazed.SetHighlighted(false);
        gazed.Activate();
        lastUsed = gazed;
        gazed = null;
        SetBar(0f, false);
    }

    void SetBar(float amount, bool visible)
    {
        if (progressBar == null) return;
        progressBar.fillAmount = amount;
        progressBar.gameObject.SetActive(visible);
    }
}
