using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z : MonoBehaviour
{
    public float velocidad = 10f; // Velocidad de movimiento
    private bool moverAdelante = true; // Variable para determinar la dirección del movimiento

    void Update()
    {
        // Verificamos si el objeto ha llegado a su límite delantero (50 en positivo) o trasero (-50 en negativo)
        if (transform.position.z >= 50f)
        {
            moverAdelante = false; // Cambiamos la dirección hacia atrás
        }
        else if (transform.position.z <= -50f)
        {
            moverAdelante = true; // Cambiamos la dirección hacia adelante
        }

        // Movemos el objeto en la dirección adecuada
        if (moverAdelante)
        {
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.back * velocidad * Time.deltaTime);
        }
    }
}