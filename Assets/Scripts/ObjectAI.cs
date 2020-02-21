using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAI : MonoBehaviour
{
    [SerializeField] Transform castPoint;
    [SerializeField] LayerMask mask;
    Rigidbody2D rb;
    Vector2 startPos;
    
    float castDistance = 5f;
    float originOffset = 0.51f;

    [SerializeField] private float speed = 0.5f; // Максимальная скорость
    [SerializeField] private float acceleration = 0; // Ускорение движения

    // Random traits
    [SerializeField] bool canWalk;
    [SerializeField] bool canOpenDoors;

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

        #region Random Traits
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
        #endregion Random Traits
    }

    void Update()
    {
        // Line of sight
        Debug.DrawRay(castPoint.position + Vector3.right * originOffset, Vector3.right * (originOffset + castDistance), Color.blue);
        RaycastHit2D hit = Physics2D.Raycast(castPoint.position + Vector3.right * originOffset, Vector3.right, castDistance, mask);

        // Movement
        if (hit.collider)
        {
            if (!hit.collider.CompareTag("Door") & (hit.collider.CompareTag("Player")))
            {
                // MoveRight();
                rb.velocity = new Vector2(1, 0);
            }
            else
            {
                if (rb.position.x > startPos.x)
                {
                    // MoveLeft();
                    rb.velocity = new Vector2(-1, 0);
                }
            }
        }
        else
        {
            // MoveLeft();
            rb.velocity = new Vector2(-1, 0);
        }
    }

    void MoveLeft()
    {
        rb.AddForce(new Vector2(-speed * acceleration, 0), ForceMode2D.Force);
        transform.localScale = new Vector2(-1, 2);
    }

    void MoveRight()
    {
        rb.AddForce(new Vector2(speed * acceleration, 0), ForceMode2D.Force);
        transform.localScale = new Vector2(1, 2);
    }
}
