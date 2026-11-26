using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeObject : MonoBehaviour
{
    public Transform targetPosition;
    public float moveSpeed = 1.5f;
    public Color highlightColor = Color.yellow;
    private Renderer rend;
    private Color originalColor;
    private bool isMoving = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    public void OnGazeEnter() => rend.material.color = highlightColor;
    public void OnGazeExit() => rend.material.color = originalColor;

    public void OnGazeSelect()
    {
        if (!isMoving && targetPosition != null)
            StartCoroutine(MoveToTarget());
    }

    private System.Collections.IEnumerator MoveToTarget()
    {
        isMoving = true;
        while (Vector3.Distance(transform.position, targetPosition.position) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position, targetPosition.position,
                moveSpeed * Time.deltaTime);
            yield return null;
        }
        isMoving = false;
    }

}
