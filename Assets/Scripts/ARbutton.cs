using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ARbutton : MonoBehaviour
{
    public UnityEvent action; //ariable que permite asignar una funcion a llamar de un objeto en escena


    void OnMouseDown()
    {
        Debug.Log("se ha pulsado el boton");
        action.Invoke(); //llama la funcion del action
    }
}
