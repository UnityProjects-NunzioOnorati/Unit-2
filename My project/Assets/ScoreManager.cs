using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name != "Player")
        {
            score++;
            Debug.Log("Score: "+score);
        }
    }
}
