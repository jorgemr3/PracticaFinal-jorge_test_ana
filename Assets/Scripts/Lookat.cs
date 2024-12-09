using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookat : MonoBehaviour
{
    Transform ubi_obj_a_mirar;
    CalcularDist auxComponenteDistance;


    private void Awake()
    {
        ubi_obj_a_mirar = GameObject.Find("Jugador").GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        auxComponenteDistance = GetComponent<CalcularDist>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanciaAlenemigo = auxComponenteDistance.getDistance();
        if (distanciaAlenemigo < 20.5f)
        {
            float varY = ubi_obj_a_mirar.position.y;
            if (varY > 3.0f)
            {
                transform.LookAt(new Vector3(
                    ubi_obj_a_mirar.position.x,
                    3.0f,
                    ubi_obj_a_mirar.position.z
                ));
            }
            else
            {
             transform.LookAt(ubi_obj_a_mirar.position);
            }
            
        }
    }
}
