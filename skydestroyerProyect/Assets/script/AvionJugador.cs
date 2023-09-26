using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvionJugador : MonoBehaviour
{
    public float maxVel = 200f;
    public float minVel = 10f;

    public GameObject cuerpoAvion;
    
    public float velocidad = 60f;
    public float giro = 90f;
    public float lecturaHorizontal, lecturaVertical, lecturaLateral;
   

    #region BULLET
    public GameObject balaPrefabDer;
    public GameObject balaPrefabIzq;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public float shotForce = 5000f;    
    private float shotRateTime;
    public float shotRate = 0;
    #endregion



    

   

    

    void Update()
    {
        
        //Aumentar la velocidad
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (velocidad <= maxVel) 
            {
                velocidad += 10;
            }
        }
        //Disminuir Velocidad
        if (Input.GetKeyDown(KeyCode.X)) 
        {
            if (velocidad <= minVel) 
            {
                velocidad += 5;
            }
        }
        //Disparar
        if (Input.GetButtonDown("Fire1")) 
        {
            if (Time.time > shotRateTime) 
            {
                GameObject newBullet;
                newBullet = Instantiate(balaPrefabDer, spawnPoint1.position, spawnPoint1.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint1.forward * shotForce);
                Destroy(newBullet, 2);//a los 2 segundos.

                newBullet = Instantiate(balaPrefabIzq, spawnPoint2.position, spawnPoint2.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint2.forward * shotForce);
                Destroy(newBullet, 2);//a los 2 segundos.
                shotRateTime = Time.time + shotRate;
            }
        }
        
         
        

        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
        //LAS ROTACIONES X,Y,Z
        lecturaHorizontal = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * lecturaHorizontal * giro * Time.deltaTime, Space.Self);//Space.Self o Space.World

        lecturaVertical = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.right * lecturaVertical * giro * Time.deltaTime * 2);

        lecturaLateral = Input.GetAxis("Lateral");
        cuerpoAvion.transform.Rotate(Vector3.forward * lecturaLateral * -giro * Time.deltaTime * 1);
        //ESTABILIZACION DE LAS ALAS
        if (lecturaLateral == 0)
        {
            cuerpoAvion.transform.rotation = Quaternion.Slerp(cuerpoAvion.transform.rotation, transform.rotation, 0.05f);
        }

       




    }

    
}