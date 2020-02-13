using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public string elevDirect;

    private GameObject player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        CircleCollider2D cc = (CircleCollider2D)other;
        if (other.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Action"))
            {
                if (elevDirect == "up")
                {
                    player.transform.position += new Vector3(0, 4.5f, 0);
                }
                else if (elevDirect == "down")
                {
                    player.transform.position += new Vector3(0, -4.5f, 0);
                }
            }
        }
    }
}
