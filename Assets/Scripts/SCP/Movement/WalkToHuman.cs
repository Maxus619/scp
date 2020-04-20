using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToHuman : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 startPos;
    Transform castPoint;
    LayerMask mask;

    [SerializeField] public float speed = 3f;
    [SerializeField] public float acceleration = 2.5f;

    float castDistance = 5f;
    float originOffset = 0.51f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = rb.position;

        castPoint = GetComponentInChildren<Transform>();
        mask = LayerMask.GetMask("Person", "Platform");
    }
    
    void Update()
    {
        // Line of sight
        Debug.DrawRay(castPoint.position + Vector3.left * originOffset, Vector3.left * (originOffset + castDistance), Color.blue);
        Debug.DrawRay(castPoint.position + Vector3.right * originOffset, Vector3.right * (originOffset + castDistance), Color.blue);

        RaycastHit2D hitLeft = Physics2D.Raycast(castPoint.position + Vector3.left * originOffset, Vector3.left, castDistance, mask);
        RaycastHit2D hitRight = Physics2D.Raycast(castPoint.position + Vector3.right * originOffset, Vector3.right, castDistance, mask);

        // TODO: Add prioritet to nearest
        if (hitLeft.collider && !hitLeft.collider.CompareTag("Door") && hitLeft.collider.CompareTag("Player"))
        {
            MoveLeft();
        }
        else if (hitRight.collider && !hitRight.collider.CompareTag("Door") && hitRight.collider.CompareTag("Player"))
        {
            MoveRight();
        }
        else
            ReturnToStartPos();
    }

    void MoveLeft()
    {
        //rb.velocity = new Vector2(-2, 0);
        rb.AddForce(new Vector2(-speed * acceleration, 0), ForceMode2D.Force);
        transform.localScale = new Vector2(-1, 2);
    }

    void MoveRight()
    {
        //rb.velocity = new Vector2(2, 0);
        rb.AddForce(new Vector2(speed * acceleration, 0), ForceMode2D.Force);
        transform.localScale = new Vector2(1, 2);
    }

    void ReturnToStartPos()
    {
        if (rb.position.x > startPos.x)
        {
            MoveLeft();
        }
        else
        {
            MoveRight();
        }
    }
}
