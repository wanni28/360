using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeInfoPoint : GazeTarget
{
    public GameObject infoPanel; // World Space UI panel
    public bool facePlayer = true; // turn panel toward camera

    protected override void Awake()
    {
        base.Awake();
        if (infoPanel != null) infoPanel.SetActive(false);
    }

    public override void Activate()
    {
        if (infoPanel == null) return;
        bool open = !infoPanel.activeSelf;
        infoPanel.SetActive(open);

        if (open && facePlayer && Camera.main != null)
        {
            Transform panel = infoPanel.transform;
            Vector3 cam = Camera.main.transform.position;
            Vector3 away = panel.position - cam;
            panel.rotation = Quaternion.LookRotation(away);
        }
    }
}

