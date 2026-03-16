using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PigDestroy : MonoBehaviour
{
    public TMP_Text score_text;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("cherry"))
        {
            ScoreManager.instance.AddScore(1);
            Debug.Log("Score: " + ScoreManager.score);
        }
        else if (collision.CompareTag("cherry2"))
        {
            ScoreManager.instance.AddScore(5);
            Debug.Log("Score: " + ScoreManager.score);
        }
    }
}
