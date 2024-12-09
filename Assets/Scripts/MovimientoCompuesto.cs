using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCompuesto : MonoBehaviour
{
    [SerializeField] float velocidad = 0.001f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float angulo = 18f * Time.deltaTime * velocidad;
        //rotacion izquierda
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, angulo * -1, 0);
        }

        //rotacion derecha
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, angulo, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * velocidad * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.forward * velocidad * -1 * Time.deltaTime;
        }
        //izquierda
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.right * velocidad * -1 * Time.deltaTime;
        }
        //derecha
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * velocidad * Time.deltaTime;
        }
    }
}
