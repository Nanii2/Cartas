using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TextoSlider : MonoBehaviour
{
    public Slider slider;
    private TextMeshProUGUI texto;

    // Start is called before the first frame update
    void Start()
    {
        texto = GetComponent<TextMeshProUGUI>();
       
    }

    public void ActualizaTexto()
    {
        texto.text = slider.value.ToString();

    }
}
