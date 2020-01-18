using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    public string state; // opened, closed, broken (в будущем)

    void Start()
    {
        state = "closed";
    }
    
    void Update()
    {
        
    }

    public void PressButton()
    {
        // TODO: Добавить проверку на поломку двери

        if (state == "closed")
        {
            while (transform.position.y < -5.75f)
            {
                transform.position = Vector2.up;
            }

            state = "opened";
        }
        else if (state == "opened")
        // else if (state == "opened" && transform.position.y == -5.75f) // Доп. проверка от бесконечного открытия
        {
            transform.Translate(Vector2.down * Time.deltaTime * 150);
            state = "closed";
        }
    }
}
