using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto con el que colisionamos se llama "Portal"
        if (collision.gameObject.CompareTag("Portal"))
        {   
             ChangeSceneUtil.Change(2);
            // Lógica para cuando el objeto colisiona con el Portal
        } else if (collision.gameObject.CompareTag("Soul"))
        {
            // Lógica para cuando el objeto colisiona con un Obstáculo
            ChangeSceneUtil.Change(0);
            
        }
        else if (CountersSingleton.Instance.GetScoreCounter() == 3)
        {
            ChangeSceneUtil.Change(1);
        }
    }
}
