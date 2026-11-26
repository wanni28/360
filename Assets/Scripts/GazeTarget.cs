using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GazeTarget : MonoBehaviour
{
    public Color highlightColor = Color.yellow;

    private Renderer rend;
    private Color originalColor;

    protected virtual void Awake()
    {
        rend = GetComponent<Renderer>();
        if (rend != null) originalColor = rend.material.color;
    }

    public void SetHighlighted(bool state)
    {
        if (rend == null) return;
        rend.material.color = state ? highlightColor : originalColor;
    }

    // Runs once the gaze has stayed for the full dwell time.
    public abstract void Activate();
}

