using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SmoothCamera : MonoBehaviour
{
    public Transform player;
    public float speed = 0.5f;

    float maxRightX = 16f;
    float minLeftX = -16f;
    float targetX;

    private void LateUpdate()
    {
        if (player.position.x >= maxRightX)
            targetX = maxRightX;
        else if (player.position.x <= minLeftX)
            targetX = minLeftX;
        else
            targetX = player.position.x;

        transform.position = Vector3.Lerp(
                transform.position,
                new Vector3(targetX, 0f, -10f),
                speed);        
    }
}