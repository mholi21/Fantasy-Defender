using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabs;

	void Start () {
		
	}
	
	void Update () {
        foreach(GameObject thisAttacker in attackerPrefabs)
        {
            if (checkSpawnTime(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
		
	}

    void Spawn (GameObject attackerPrefab)
    {
        GameObject attacker = Instantiate(attackerPrefab) as GameObject;
        attacker.transform.parent = transform;
        attacker.transform.position = transform.position;
    }

    bool checkSpawnTime(GameObject attackerPrefab)
    {
        Attacker attacker = attackerPrefab.GetComponent<Attacker>();
        float spawnDelay = attacker.spawnEverySeconds;
        float spawnsPerSecond = 1 / spawnDelay;

        if (Time.deltaTime > spawnDelay)
        {
            Debug.LogWarning("Spawn rate capped by frame rate!");
        }

        float threshold = spawnsPerSecond * Time.deltaTime / 5;

        return (Random.value < threshold);
    }
}
