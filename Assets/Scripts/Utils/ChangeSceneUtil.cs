using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneUtil : MonoBehaviour
{

    public ChangeSceneUtil()
    {

    }
    // void Start()
    // {

    // }

    // void Update()
    // {

    // }

    public static void Change(int index)
    {
        SceneManager.LoadScene(index);
    }

    // public int GetCurrentSceneIndex()
    // {
    //     return SceneManager.GetActiveScene().buildIndex;
    // }
}
