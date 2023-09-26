using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HELICE2 : MonoBehaviour
{
    public float velocidadRotacion = 500.0f; // Velocidad de rotación de las hélices

    // Update se llama una vez por frame
    void Update()
    {
        // Girar las hélices en el eje Z
        transform.Rotate(Vector3.forward * velocidadRotacion * Time.deltaTime);
    }
}