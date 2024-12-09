using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnemigo : MonoBehaviour
{
     float velocidad;
    Transform ubi_personaje;
    CalcularDist auxComponenteDistance;

    void Awake(){
        ubi_personaje=GameObject.Find("Jugador").GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        auxComponenteDistance = GetComponent<CalcularDist>();
        velocidad = 0.25f * Time.deltaTime;
    }

    // Update is called once per frame
    void Update(){
        float distanciaAlenemigo = auxComponenteDistance.getDistance();
        if (distanciaAlenemigo < 6.5f)
        {
        transform.position = Vector3.MoveTowards(transform.position,ubi_personaje.position,velocidad);
    }
}
}
