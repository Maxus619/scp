using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoorButton : MonoBehaviour
{
    public AutoDoor door;
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Action"))
            {
                door.PressButton();
            }
        }
    }
}
