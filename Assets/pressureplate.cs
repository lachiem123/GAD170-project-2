using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week6 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject door; // Assign the door GameObject in the inspector
    public float openHeight = 3.0f; // Height to move the door up to open
    public float moveSpeed = 2.0f; // Speed at which the door opens
    private Vector3 originalPosition;
    private bool isPressed = false;

    void Start()
    {
        if (door != null)
        {
            originalPosition = door.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure only the player triggers it
        {
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPressed = false;
        }
    }

    void Update()
    {
        if (isPressed)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }

    private void OpenDoor()
    {
        Vector3 targetPosition = originalPosition + new Vector3(0, openHeight, 0);
        door.transform.position = Vector3.MoveTowards(door.transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    private void CloseDoor()
    {
        door.transform.position = Vector3.MoveTowards(door.transform.position, originalPosition, moveSpeed * Time.deltaTime);
    }

}
