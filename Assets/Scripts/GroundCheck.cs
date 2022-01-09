using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GroundCheck : MonoBehaviour
{
    public Movement movement;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!movement.IsOnGround && collision.CompareTag("Ground"))
        {
            movement.SetIsOnGround(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (movement.IsOnGround && collision.CompareTag("Ground") )
        {
            movement.SetIsOnGround(false);
        }
    }
}