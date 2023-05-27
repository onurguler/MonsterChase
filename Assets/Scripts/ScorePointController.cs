using System;
using UnityEngine;

public class ScorePointController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            string monsterName = gameObject.GetComponentInParent<Monster>().gameObject.name;
            int score = monsterName.Contains("Ghost") ? 200 : 100;
            score *= Math.Abs(Convert.ToInt32(gameObject.GetComponentInParent<Monster>().speed));
            ScoreManager.instance.AddScore(score);
            Destroy(gameObject);
        }
    }
}
