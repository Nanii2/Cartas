using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using TMPro;

public enum CardPose { NO_POSE, DEFAULT, ATTACK, DEFENSE, DESTROYED };

public class ARCard1 : MonoBehaviour
{
    public CardPose pose = CardPose.DEFAULT;
    public ImageTargetBehaviour target;

    public int ATK = 0;
    public int DEF = 0;

    public TextMeshPro textoATK, textoDEF;
    
    public GameObject botonATK, botonDEF, modeloATK, spriteDEF, IndicadorJ1, IndicadorJ2, spriteDestruido;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<ImageTargetBehaviour>();
        pose = CardPose.DEFAULT;
        ActualizaTextos();
        ActualizaSegunEstado();
        
    }
    public void ResetCarta()
    {

        pose = CardPose.DEFAULT;
        ActualizaSegunEstado();
        IndicadorJ1.SetActive(false);
        IndicadorJ2.SetActive(false);

    }

   
    // Update is called once per frame
    void Update()
    {
        /*if (target.TargetStatus.Status == BatteryStatus.NO_POSE)
        {
            Debug.Log("EL TARGET" + target.TargetName + "no está en pantalla");
        }
        else
        {
            Debug.Log("EL TARGET" + target.TargetName + "aparece");

        }*/
    }
    public Status GetStatus()
    {

        return target.TargetStatus.Status;


    }

    private void ActualizaTextos()
    {
        textoATK.text = "ATK: '\n'" + ATK.ToString();
        textoATK.text = "DEF: '\n'" + DEF.ToString();

    }

    public void PonPosicionAtaque()
    {
        pose = CardPose.ATTACK;
        ActualizaSegunEstado();
    }
    
    public void PonPosicionDef()
    {
        pose = CardPose.DEFENSE;
        ActualizaSegunEstado();


    }

    private void ActualizaSegunEstado()
    {
        switch(pose)
        {
            case CardPose.DEFAULT:
                modeloATK.SetActive(false);
                botonATK.SetActive(true);
                botonDEF.SetActive(true);
                spriteDEF.SetActive(false);
                spriteDestruido.SetActive(false);
                break;
            case CardPose.ATTACK:
                modeloATK.SetActive(true);
                botonATK.SetActive(true);
                botonDEF.SetActive(true);
                spriteDEF.SetActive(false);
                spriteDestruido.SetActive(false);
                break;
            case CardPose.DEFENSE:
                modeloATK.SetActive(false);
                botonATK.SetActive(true);
                botonDEF.SetActive(true);
                spriteDEF.SetActive(true);
                spriteDestruido.SetActive(false);
                break;
            case CardPose.DESTROYED:
                modeloATK.SetActive(false);
                botonATK.SetActive(true);
                botonDEF.SetActive(true);
                spriteDEF.SetActive(false);
                spriteDestruido.SetActive(true);
                break;

        }


    }

    public int GetCurrentStat()
    {
       
       return (pose == CardPose.ATTACK) ? ATK : DEF;

    }

    public void PonEstado(CardPose estado)
    {
        pose = estado;
        ActualizaSegunEstado();


    }

    public void AsignaPropietario(bool j2)
    {

        IndicadorJ1.SetActive(!j2);
        IndicadorJ2.SetActive(j2);

    }
}
