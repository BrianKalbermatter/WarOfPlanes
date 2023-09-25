using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X : MonoBehaviour
{
    public float velocidad = 10f; // Velocidad de movimiento
    private bool moverDerecha = true; // Variable para determinar la dirección del movimiento

    void Update()
    {
        // Verificamos si el objeto ha llegado a su límite derecho (50 en positivo) o izquierdo (-50 en negativo)
        if (transform.position.x >= 50f)
        {
            moverDerecha = false; // Cambiamos la dirección a la izquierda
        }
        else if (transform.position.x <= -50f)
        {
            moverDerecha = true; // Cambiamos la dirección a la derecha
        }

        // Movemos el objeto en la dirección adecuada
        if (moverDerecha)
        {
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);
        }
    }
}