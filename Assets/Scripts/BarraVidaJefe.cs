using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVidaJefe : MonoBehaviour
{
    /*En este Script aparece un raro error si se le hacen cambios bruscos al prefab de los enemigos al que esta ligado, se soluciona retirando el script y volverlo a poner
     *en el inspector. Si la primera solucion no fue efectiva, crear un nuevo script y agregarlo nuevamente a la BarraDeVida del canvas en la jerarquia
     *Este error no tiene una logica cuando ocurre, por lo cual es la solucion de momento.*/
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void CambiarVidaMaxima(float vidaMaxima)
    {
        slider.maxValue = vidaMaxima;
    }

    public void CambiarVidaActual(float cantidadVida)
    {
        slider.value = cantidadVida;
    }

    public void InicializarBarraDeVida(float cantidadVida)
    {
        CambiarVidaMaxima(cantidadVida);
        CambiarVidaActual(cantidadVida);
    }
}
