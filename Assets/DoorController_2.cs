using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController_2 : MonoBehaviour
{
    [Header("Objects we need to open the door")] 
    [SerializeField] private Transform door;

    [Header("Settings for door open and close")] 
    [SerializeField] private float rotationSpeed;

    private bool isOpened = false;
    private bool isClosed = false;

    private void Update()
    {
        if (isOpened)
        {
            float angle = Mathf.MoveTowards(door.transform.eulerAngles.y, 90f, rotationSpeed * Time.deltaTime);
            door.transform.rotation = Quaternion.Euler(0, angle,0);

        }

        if (isClosed)
        {
            float angle = Mathf.MoveTowards(door.transform.eulerAngles.y, 0f, rotationSpeed * Time.deltaTime);
            door.transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }
    
    // If the targeted object is in the zone where the isTrigger is checked and the target is Cleint, It will make isOpened true to open door 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Client")
        {
            
            isOpened = true;
            isClosed = false;
        }
    }
    // When client steps out of the area, the door will close.
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Client")
        {
            isOpened = false;
            isClosed = true;
        }
    }
}
