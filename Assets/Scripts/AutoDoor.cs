using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    Rigidbody2D rb;
    private float startPosition;

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
            rb.velocity = new Vector2(0, 10);
            if (rb.position.y >= (startPosition + 2.992518))
            {
                rb.velocity = new Vector2(0, 0);
                state = "opened";
            }
            //transform.Translate(Vector2.up * Time.deltaTime * 150);
            
        }
        else if (state == "closing")
        {
            rb.velocity = new Vector2(0, -10);
            
            if (rb.position.y <= startPosition)
            {
                rb.velocity = new Vector2(0, 0);
                state = "closed";
            }
            
            //transform.Translate(Vector2.down * Time.deltaTime * 150);
            
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
