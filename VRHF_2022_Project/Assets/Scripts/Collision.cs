using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameLogic gameLogic;

    private void OnTriggerEnter(Collider other)
    {
        // do nothing if other is not player
        if (!other.CompareTag("Player")) return;

        // reposition the player and lose a life
        other.transform.position = new Vector3(0, 0.2f, -12);   // this is hardcoded, maybe find a better solution
        gameLogic.LoseLife();
    }
}
