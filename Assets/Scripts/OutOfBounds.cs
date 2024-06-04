using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Guide: https://www.youtube.com/watch?v=_i7hDXs1dvo
public class OutOfBounds : MonoBehaviour
{
    public Vector3 SpawnPoint;

    // When an object exits this bounding box
    private void OnTriggerExit2D(Collider2D other) 
    {   
        // Check for player exiting this box
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player out of bounds!");
            other.gameObject.transform.position = SpawnPoint;
            other.attachedRigidbody.velocity = new Vector2(0, 0);
            other.attachedRigidbody.angularVelocity = 0f;
        }
        
        // If an item exits this box, destroy it
        else if (other.CompareTag("Item") || other.CompareTag("Enemy") || other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
        }
    }
}
