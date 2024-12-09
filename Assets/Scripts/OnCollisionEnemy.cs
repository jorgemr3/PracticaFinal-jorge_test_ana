using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnCollisionEnemy : MonoBehaviour
{
    TextMeshProUGUI textLifeCounter;

    private void Awake()
    {
        textLifeCounter = GameObject.Find("LifeCounter").GetComponent<TextMeshProUGUI>();
        textLifeCounter.text = CountersSingleton.Instance.GetLifeCounter().ToString();
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            CountersSingleton.Instance.RemoveLife();
            textLifeCounter.text = CountersSingleton.Instance.GetLifeCounter().ToString();

            if (CountersSingleton.Instance.GetLifeCounter() == 0)
            {
                ChangeSceneUtil.Change(2);
            }
        }
    }

}
