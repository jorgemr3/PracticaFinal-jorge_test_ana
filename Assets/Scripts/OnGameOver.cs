using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnGameOver : MonoBehaviour
{
    TextMeshProUGUI textLifeCounter;
    TextMeshProUGUI textScoreCounter;

    private void Awake()
    {
        textLifeCounter = GameObject.Find("LifeCounter").GetComponent<TextMeshProUGUI>();
        textLifeCounter.text = CountersSingleton.Instance.GetLifeCounter().ToString();

        textScoreCounter = GameObject.Find("ScoreCounter").GetComponent<TextMeshProUGUI>();
        textScoreCounter.text = CountersSingleton.Instance.GetScoreCounter().ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            CountersSingleton.Instance.ResetCounters();
            ChangeSceneUtil.Change(3);
        }
    }


}
