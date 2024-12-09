using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGameStart : MonoBehaviour
{
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeSceneUtil.Change(0);
        }
    }
}
