using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcularDist : MonoBehaviour
{
    Transform ubi_obj_a_calc_dist;
    float distance;

    public float getDistance()
    {
        return distance; // la raiz cuadrada de la suma de las diferencias de las x's y las y's
    }
    private void Awake()
    {
        ubi_obj_a_calc_dist = GameObject.Find("Jugador").GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(
        transform.position,
        ubi_obj_a_calc_dist.position);
    }
}
