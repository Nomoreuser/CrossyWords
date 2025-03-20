using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Drag the player into this slot in the Inspector
    public Vector3 offset = new Vector3(0, 5, -5); // Adjust offset for better view

    void LateUpdate()
    {
        // Follow the player's position but do NOT rotate
        transform.position = player.position + offset;
    }
}
