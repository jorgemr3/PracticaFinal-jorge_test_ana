using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class CapsulasDestruidas : MonoBehaviour
{
    TextMeshProUGUI textScoreCounter;

    private void Awake()
    {
        textScoreCounter = GameObject.Find("ScoreCounter").GetComponent<TextMeshProUGUI>();
        textScoreCounter.text = CountersSingleton.Instance.GetScoreCounter().ToString();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision other)
    {
        GameObject obj = other.gameObject;
        if (obj.CompareTag("Puntos"))
        {
            CountersSingleton.Instance.AddScore(1);
            textScoreCounter.text = CountersSingleton.Instance.GetScoreCounter().ToString();
            Destroy(obj);
            if (CountersSingleton.Instance.GetScoreCounter() == 3)
            {
                ChangeSceneUtil.Change(1);
            }

        }
    }
}
