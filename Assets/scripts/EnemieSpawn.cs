using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;

public class EnemieSpawn : MonoBehaviour
{
    public GameObject asteroide;
    public float timer = 3.0f;
    public GameObject[] SpawnPositions;
    void Start()
    {
        StartCoroutine(Countdown2());
    }

    // Update is called once per frame
    void Update()
    {
    }
    private IEnumerator Countdown2()
    {
        while (true)
        {
            yield return new WaitForSeconds(timer); //wait 2 seconds
            if (timer >= 0.7f) {
                timer -= 0.01f;
            }
            int indexSpawn = UnityEngine.Random.Range(0, SpawnPositions.Length);

            //pegar uma posicao aleatoria de um array pra instanciar
            Instantiate(asteroide, SpawnPositions[indexSpawn].transform.position, Quaternion.identity);
        }
    }
}
