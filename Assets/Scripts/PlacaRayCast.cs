using System.Collections;
using UnityEngine;

public class RaycastActivator : MonoBehaviour
{
    public Transform raycastOrigin; // El origen del raycast (puede ser el jugador o cualquier objeto)
    public float raycastDistance = 10f; // Distancia máxima del raycast
    // public float raycastInterval = 0.1f; // Intervalo de tiempo para cada comprobación del raycast
    public GameObject[] targetObjects; // Los objetos con los que el raycast debe colisionar (se asignan desde el Inspector)

    // private bool isColliding = false; // Estado de la colisión

    RaycastHit hit; // Información del objeto golpeado por el raycast

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Jugador")) // Asegúrate de que la placa tiene el tag "Placa"
        {
            // isColliding = true; // Activa el raycast
            Debug.Log("Jugador ha colisionado con la placa, raycast activado.");
            StartCoroutine(ActivateRaycast()); // Inicia la corrutina para el raycast
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Jugador"))
        {
            // isColliding = false; // Desactiva el raycast
            Debug.Log("Jugador ha salido de la placa, raycast desactivado.");
            StopCoroutine(ActivateRaycast()); // Detiene la corrutina si sale de la placa
        }
    }

    private IEnumerator ActivateRaycast()
    {
            // RaycastHit hit;
            // Ray ray = new Ray(raycastOrigin.position, raycastOrigin.forward);
            // Disparamos el raycast hacia adelante desde el origen
            if (Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, raycastDistance))
            {
                // Comprobamos si el objeto golpeado es uno de los asignados en el Inspector
                foreach (GameObject target in targetObjects)
                {
                    // if (hit.collider.gameObject == target)
                    // {
                    //     Debug.Log("Raycast activado, golpeando el objeto");
                    //      Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * raycastDistance, Color.red, 0.1f);
                    //     // Aquí puedes añadir lo que sucede cuando el raycast golpea uno de los objetos asignados.
                    // }
                    // Calculamos la dirección hacia el target
                    Vector3 directionToTarget = target.transform.position - raycastOrigin.position;

                    // Dibujamos el rayo hacia el target
                    // Disparamos el raycast hacia el target
                   
                    Ray ray = new(raycastOrigin.position, raycastOrigin.forward); // Creamos el rayo con la dirección normalizada

                    // Comprobamos si el raycast golpea el target
                    if (Physics.Raycast(ray, out hit, raycastDistance))
                    {
                        if (hit.collider.gameObject == target)
                        {
                            Debug.Log("Raycast activado, golpeando el objeto");
                            Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * raycastDistance, Color.red, 0.1f);
                            // Aquí puedes añadir lo que sucede cuando el raycast golpea uno de los objetos asignados.
                        }
                    }
                }
            }

            // Espera antes de volver a disparar el raycast
            yield return new WaitForSeconds(0.1f);
        }
    }

// using UnityEngine;

// public class PlacaRayCast : MonoBehaviour
// {
//     public Mandelbrot mandelbrotScript;  // Referencia al script de Mandelbrot
//     public float zoomChange = 2f;        // Cuánto cambiar el zoom cuando entre o salga del trigger

//     // bool enter= false;

//     void OnTriggerEnter(Collider other)
//     {
//         // Verificar si el jugador entró al trigger (puedes cambiar "Player" por el tag que uses)
//         if (other.CompareTag("Jugador"))
//         {
//             Debug.Log("Jugador ha entrado en el trigger de la placa.");
//             // Aumentar el zoom del script de Mandelbrot
//             mandelbrotScript.zoom += zoomChange;
//             Debug.Log("Zoom aumentado. Nuevo zoom: " + mandelbrotScript.zoom.ToString());
//             mandelbrotScript.GenerarFractal();  // Regenerar la imagen de Mandelbrot con el nuevo zoom
//         }
//     }

//     void OnTriggerExit(Collider other)
//     {
//         // Verificar si el jugador salió del trigger
//         if (other.CompareTag("Jugador"))
//         {
//             Debug.Log("Jugador ha salido en el trigger de la placa.");
//             // Disminuir el zoom del script de Mandelbrot
//             // mandelbrotScript.zoom -= zoomChange;
//             Debug.Log("Zoom disminuido. Nuevo zoom: " + mandelbrotScript.zoom.ToString());
//             // mandelbrotScript.GenerarFractal(); 
//             // Regenerar la imagen de Mandelbrot con el nuevo zoom
//         }
//     }
// }

// using Unity.VisualScripting;
// using UnityEngine;

// public class PlacaRayCast : MonoBehaviour
// {
//     public CantorSet Fractal;  // Referencia al script de Mandelbrot
//     public float NewSeparacion = 2f;        // Cuánto cambiar el zoom cuando entre o salga del trigger

//     // bool enter= false;

//     void OnTriggerEnter(Collider other)
//     {
//         // Verificar si el jugador entró al trigger (puedes cambiar "Player" por el tag que uses)
//         if (other.CompareTag("Jugador"))
//         {
//             Debug.Log("Jugador ha entrado en el trigger de la placa.");
//             // Aumentar el zoom del script de Mandelbrot
//             Fractal.Separacion += NewSeparacion;
//             Debug.Log("Separacion aumentado. Nueva separacion: " + Fractal.Separacion.ToString());
//             Fractal.GenerateCantorSet();  // Regenerar la imagen de Mandelbrot con el nuevo zoom
//         }
//     }

//     void OnTriggerExit(Collider other)
//     {
//         // Verificar si el jugador salió del trigger
//         if (other.CompareTag("Jugador"))
//         {
//             Debug.Log("Jugador ha salido en el trigger de la placa.");
//             // Disminuir el zoom del script de Mandelbrot
//             Fractal.Separacion -= NewSeparacion;
//             Debug.Log("Separacion disminuido. Nuevo Separacion: " + Fractal.Separacion.ToString());
//             Fractal.GenerateCantorSet(); 
//             // Regenerar la imagen de Mandelbrot con el nuevo zoom
//         }
//     }
// }

