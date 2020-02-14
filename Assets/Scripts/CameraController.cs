using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb;
    private float coefficient;  // Коэффициент расстояния до игрока

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 player2dPosition = new Vector2(player.position.x, player.position.y);
        coefficient = Mathf.Pow((player2dPosition - rb.position).magnitude, 2);
        if (player2dPosition != rb.position)
        {
            rb.velocity = (player2dPosition - rb.position) * coefficient * 5;
        }
    }

}
