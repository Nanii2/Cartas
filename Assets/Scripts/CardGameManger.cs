using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGameManger : MonoBehaviour
{
    [SerializeField] public ARCard1[] cartasEnEscena;

    [SerializeField] private List<ARCard1> cartasTrackeadas;

    public int nCartasTrackeadas = 0;
    private int nCartasDerrotadas = 0;

    public GameObject botonCombate;

    public Slider sliderJ1;
    public Slider sliderJ2;
    public int vidaMaxima = 4000;

    public Transform posJ1;
    public Transform posJ2;

    public ARCard1 cartaJ1;
    public ARCard1 cartaJ2;


    // Start is called before the first frame update
    void Start()
    {
        cartasEnEscena = FindObjectsOfType<ARCard1>();
        sliderJ1.maxValue = sliderJ1.value = vidaMaxima;
        sliderJ2.maxValue = sliderJ2.value = vidaMaxima;
    }

    public void ResetGame()
    {
        foreach (ARCard1 card in cartasEnEscena)
        {
            card.ResetCarta();

        }
        nCartasDerrotadas = 0;

    }

    // Update is called once per frame
    void Update()
    {
        ActualizaListaCartas();
        CompruebaBotonCombate();
        CompruebaPropietarioCartas();
        ResetGame();
    }
    public void Combate()
    {
        //COGEMOS LAS 2 PRIMERAS CARTAS TRACKEADAS

        int statJ1 = cartaJ1.GetCurrentStat();
        int statJ2 = cartaJ2.GetCurrentStat();

        if(statJ1 > statJ2)
        {
            //destruimos carta j2
            cartaJ2.PonEstado(CardPose.DESTROYED);
            nCartasDerrotadas++;
            //restar vida j2
            sliderJ2.value -= statJ1 - statJ2;
        }
        else if (statJ1 < statJ2)
        {
            cartaJ1.PonEstado(CardPose.DESTROYED);
            nCartasDerrotadas++;
            sliderJ2.value -= statJ2 - statJ1;
        }
        else
        {
            cartaJ1.PonEstado(CardPose.DESTROYED);
            cartaJ2.PonEstado(CardPose.DESTROYED);
        }

        CheckGameOver();

    }

    private void CompruebaPropietarioCartas()
    {

        if(nCartasTrackeadas >=2 )
        {
            Transform  posC1 = cartasTrackeadas[0].transform ;
            Transform  posC2 = cartasTrackeadas[1].transform ;

            float dist_J1_C1 = Vector3.Distance(posJ1.position, posC1.position);
            float dist_J1_C2 = Vector3.Distance(posJ1.position, posC2.position); 

            float dist_J2_C1 = Vector3.Distance(posJ2.position, posC1.position); 
            float dist_J2_C2 = Vector3.Distance(posJ2.position, posC2.position);

            if (dist_J1_C1 < dist_J1_C2)
            {
                cartaJ1 = cartasTrackeadas[0];
                cartaJ2 = cartasTrackeadas[1];

            }
            else
            {
                cartaJ1 = cartasTrackeadas[1];
                cartaJ2 = cartasTrackeadas[0];

            }
            cartaJ1.AsignaPropietario(false);
            cartaJ2.AsignaPropietario(true);
        }

    }

    private void CompruebaBotonCombate()
    {
        if (nCartasTrackeadas >= 2)
        {

            ARCard1 card1 = cartasTrackeadas[0];
            ARCard1 card2 = cartasTrackeadas[1];

            if((card1.pose == CardPose.ATTACK || card1.pose == CardPose.DEFENSE) && 
              (card2.pose == CardPose.ATTACK || card2.pose ==CardPose.DEFENSE))
            {
                botonCombate.SetActive(true);

            }
            else
            {
                botonCombate.SetActive(false);

            }
        }
       


    }

    private void ActualizaListaCartas()
    {

        cartasTrackeadas.Clear();
        nCartasTrackeadas = 0;

        foreach (ARCard1 carta in cartasEnEscena)
        {

            if(carta.GetStatus() != Vuforia.Status.NO_POSE)
            {
                cartasTrackeadas.Add(carta);
                nCartasTrackeadas ++;
            }

        }
       /* for( int i = 0; i < cartasEnEscena.Length; i++)
        {

            cartasEnEscena[i].GetStatus();
        }*/
    }

    public void CheckGameOver()
    {
        if (sliderJ1.value <= 0)
        {

        }
        else if (sliderJ2.value <= 0)
        {


        }

        if(nCartasDerrotadas == cartasEnEscena.Length)
        {
            if(sliderJ1.value > sliderJ2.value)
            {


            }
            else if (sliderJ2.value < sliderJ1.value)
            {



            }
            else
            {


            }
        }
    }
    
}
