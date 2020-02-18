using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBoyAI : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] int currentLevel = 0;
    bool task = false; // TODO: Format into a string
    int taskLevel;
    float containmentX;

    // Lift coordinates
    float lift0 = 3.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // MoveToContainment(-1, -16f);
    }
    
    void Update()
    {
        if (task)
        {
            if (currentLevel > taskLevel)
            {
                if (transform.position.x > lift0)
                {
                    rb.velocity = new Vector2(-2, 0);
                }
                else
                {
                    transform.position += new Vector3(0, -9f, 0);
                    currentLevel = -1;
                }
            }
            else if (currentLevel == taskLevel)
            {
                if (containmentX < transform.position.x)
                {
                    rb.velocity = new Vector2(-2, 0);
                }
            }
            else // currentLevel < taskLevel
            {

            }
        }
    }

    public void MoveToContainment(int level, float x)
    {
        task = true;
        taskLevel = level;
        containmentX = x;
    }
}
