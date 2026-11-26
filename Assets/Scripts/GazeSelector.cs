using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeSelector : MonoBehaviour
{
     public float gazeDistance = 10f;
    public float dwellTime = 2f;
    private GazeObject currentTarget;
    private float gazeTimer;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, gazeDistance))
        {
            GazeObject target = hit.collider.GetComponent<GazeObject>();
            if (target != null)
            {
                if (target != currentTarget)
                {
                    currentTarget?.OnGazeExit();
                    currentTarget = target;
                    gazeTimer = 0f;
                    currentTarget.OnGazeEnter();
                }
                gazeTimer += Time.deltaTime;
                if (gazeTimer >= dwellTime)
                {
                    currentTarget.OnGazeSelect();
                    gazeTimer = 0f;
                }
                return;
            }
        }
        currentTarget?.OnGazeExit();
        currentTarget = null;
        gazeTimer = 0f;
    }

}
