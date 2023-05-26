using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;

    private List<GameObject> spawnedMonsters = new();

    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    void FixedUpdate()
    {
        List<GameObject> monstersToRemove = new();
        
        foreach (GameObject monster in spawnedMonsters)
        {
            float speed = monster.GetComponent<Monster>().speed;
            bool isOutOfBound = speed > 0 
                ? monster.transform.position.x > rightPos.position.x
                : monster.transform.position.x < leftPos.position.x;

            if (isOutOfBound)
            {
                monstersToRemove.Add(monster);
            }
        }

        foreach (GameObject monster in monstersToRemove)
        {
            spawnedMonsters.Remove(monster);
            Destroy(monster);
        }
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]);

            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10);
            }
            else
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }

            spawnedMonsters.Add(spawnedMonster);
        }
    }
}
