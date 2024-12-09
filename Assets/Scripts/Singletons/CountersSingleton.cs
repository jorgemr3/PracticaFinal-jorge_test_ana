using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountersSingleton : MonoBehaviour
{
    public static CountersSingleton Instance { get; private set; }

    int lifeCounter = 9;
    int scoreCounter = 0;

    void Awake()
    {
        if (Instance != null && Instance != this && this != null)
        {
            Destroy(gameObject);
            //aqui se da cuenta que ya existe una instancia y la destruye para que no se duplique
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            //aqui se crea la instancia
        }
    }

    public void AddScore(int score)
    {
        scoreCounter += score;
    }

    public void RemoveLife()
    {
        lifeCounter--;
    }

    public void ResetCounters()
    {
        lifeCounter = 9;
        scoreCounter = 0;

    }

    public int GetLifeCounter()
    {
        return lifeCounter;
    }

    public int GetScoreCounter()
    {
        return scoreCounter;
    }


}
