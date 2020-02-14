using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public string elevDirect;
    public GameObject camera;

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
        if (other.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Action"))
            {
                if (elevDirect == "up")
                {
                    player.transform.position += new Vector3(0, 3f, 0);
                }
                else if (elevDirect == "down")
                {
                    player.transform.position += new Vector3(0, -3f, 0);
                }
                camera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
            }
        }
    }
}
