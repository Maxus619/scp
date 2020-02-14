using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    Rigidbody2D rb;
    private float startPosition;
    private float coefficient;

    public string state; // opened, closed, opening, closing, broken (в будущем)
    // TODO: Переписать это говно
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        state = "closed";
        startPosition = rb.position.y;
    }
    
    void Update()
    {
        if (state == "opening")
        {
            coefficient = 1 / Mathf.Pow(startPosition + 2.992518f - rb.position.y, 2.4f);
            if (rb.position.y <= (startPosition + 1.5)) 
            { 
                rb.velocity = new Vector2(0, coefficient * 15); 
            }
            if (rb.position.y >= (startPosition + 2.992518f))
            {
                rb.velocity = new Vector2(0, 0);
                rb.transform.position = new Vector2(rb.position.x, startPosition + 2.992518f);
                state = "opened";
            }
            
        }
        else if (state == "closing")
        {
            coefficient = 1 / Mathf.Pow(rb.position.y - startPosition, 2.4f);
            if (rb.position.y >= startPosition + 1.3)
            {
                rb.velocity = new Vector2(0, - coefficient * 15);
            }
            if (rb.position.y <= startPosition)
            {
                rb.velocity = new Vector2(0, 0);
                rb.transform.position = new Vector2(rb.position.x, startPosition);
                state = "closed";
            } 
        }
    }

    public void PressButton()
    {
        // TODO: Добавить проверку на поломку двери

        if (state == "closed")
        {
            state = "opening";
        }
        else if (state == "opened")
        {
            state = "closing";
        }
    }
}
