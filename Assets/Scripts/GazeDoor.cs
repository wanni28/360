using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GazeDoor : GazeTarget
{
    [SerializeField] private string nextSceneName;

    public override void Activate()
    {
        if (!string.IsNullOrWhiteSpace(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("", this);
        }
    }
}
