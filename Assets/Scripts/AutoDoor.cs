using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    public string state; // opened, closed, opening, closing, broken (в будущем)
    // TODO: Переписать это говно
    void Start()
    {
        state = "closed";
    }
    
    void Update()
    {
        if (state == "opening")
        {
            transform.Translate(Vector2.up * Time.deltaTime * 15);
            state = "opened";
        }
        else if (state == "closing")
        {
            transform.Translate(Vector2.down * Time.deltaTime * 15);
            state = "closed";
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
