using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvionJugador : MonoBehaviour
{
    public float velocidadMaxima = 20.0f;
    public float fuerzaEmpuje = 30.0f;
    public float velocidadRotacion = 2.0f;
    public GameObject balaPrefab;
    public Transform[] puntosDisparo; // Dos puntos de disparo
    public float velocidadDisparo = 10.0f;
    public float cadenciaDisparo = 0.2f;
    public float sensibilidadMouse = 2.0f;

    private float tiempoUltimoDisparo = 0.0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Desactivar gravedad para vuelo en el aire

        // Fijar el cursor en el centro de la pantalla y ocultarlo
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Movimiento del avión con teclas de flecha y controles verticales
        float inputThrottle = Input.GetAxis("Vertical"); // Acelerador
        float inputRoll = Input.GetAxis("Horizontal"); // Control de rolido (izquierda/derecha)
        float inputAscend = Input.GetKey(KeyCode.Q) ? 1.0f : 0.0f; // Ascender (Q)
        float inputDescend = Input.GetKey(KeyCode.E) ? 1.0f : 0.0f; // Descender (E)

        // Aplicar fuerza para mover el avión en la dirección deseada
        Vector3 fuerzaAvance = transform.forward * inputThrottle * fuerzaEmpuje;
        Vector3 fuerzaVertical = transform.up * (inputAscend - inputDescend) * fuerzaEmpuje;
        rb.AddForce(fuerzaAvance + fuerzaVertical);

        // Control de rotación hacia la posición del mouse
        float inputPitch = -Input.GetAxis("Mouse Y") * sensibilidadMouse;
        float inputYaw = Input.GetAxis("Mouse X") * sensibilidadMouse;

        // Aplicar rotación relativa al movimiento del mouse
        Quaternion rotacionMouse = Quaternion.Euler(inputPitch, inputYaw, 0);
        rb.rotation *= rotacionMouse;

        // Limitar la velocidad del avión
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, velocidadMaxima);

        // Disparo de la ametralladora con la barra espaciadora
        if (Input.GetKey(KeyCode.Space) && Time.time > tiempoUltimoDisparo + cadenciaDisparo)
        {
            Disparar();
            tiempoUltimoDisparo = Time.time;
        }
    }

    void Disparar()
    {
        foreach (Transform puntoDisparo in puntosDisparo)
        {
            GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);
            Rigidbody rbBala = bala.GetComponent<Rigidbody>();
            rbBala.velocity = puntoDisparo.up * velocidadDisparo;
            Destroy(bala, 2.0f);
        }
    }
}