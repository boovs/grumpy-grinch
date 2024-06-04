using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// --- Reference(s) ---
// Camera follow code from Anup Prasad
// Referenced from: https://www.youtube.com/watch?v=FXqwunFQuao

public class CameraFollow : MonoBehaviour
{
    // Camera variables
    public float followSpeed = 3f;
    public float verticalOffset = 0f;
    public Transform target;        // target should be 'player'

    // Update is called once per frame
    void Update()
    {
        // Move camera position based on where player is
        Vector3 newPos = new Vector3(target.position.x, (target.position.y + verticalOffset), -10f);
        // Use smooth linear (SLERP) interpolate to new position
        transform.position = Vector3.Slerp(transform.position, newPos, (followSpeed * Time.deltaTime));
    }
}
