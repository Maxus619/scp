using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAI : MonoBehaviour
{
    [SerializeField] Transform castPoint;
    Rigidbody2D rb;
    Vector2 startPos;
    float castDistance = 2f;

    // Random traits
    [SerializeField] bool canWalk;

    [SerializeField] string dangerClass;
    string[] dangerClassArr = { "safe", "euclid", "keter" };

    [SerializeField] string trait;

    string[] safeTraits = { "heal", "stealItem" };
    string[] euclidTraits = { "" };
    string[] keterTraits = { "" };


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = rb.position;

        // canWalk
        if (Random.value < 0.5)
        {
            canWalk = false;
        }
        else
        {
            canWalk = true;
        }

        // dangerClass
        dangerClass = dangerClassArr[Random.Range(0, dangerClassArr.Length - 1)];

        // trait
        if (dangerClass == "safe")
        {
            trait = safeTraits[Random.Range(0, safeTraits.Length - 1)];
        }
        else if (dangerClass == "euclid")
        {
            trait = euclidTraits[Random.Range(0, euclidTraits.Length - 1)];
        }
        else
        {
            trait = keterTraits[Random.Range(0, keterTraits.Length - 1)];
        }
    }
    
    void Update()
    {
        // Line of sight
        RaycastHit2D hit = Physics2D.Raycast(castPoint.position, Vector3.right * castDistance);
        // Debug.DrawLine(castPoint.position, Vector3.right * castDistance, Color.blue);

        // Movement
        if (hit.collider && hit.collider.CompareTag("Player"))
        {
            rb.velocity = new Vector2(1, 0);
        }
        else
        {
            if (rb.position.x > startPos.x)
            {
                rb.velocity = new Vector2(-1, 0);
            }
        }        
    }
}
