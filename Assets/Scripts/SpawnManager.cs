using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

using GameDifficulty = Difficulty.difficulty;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemySpawns;
    private GameManager gameManager;

    private UnityEngine.Vector2 enemyStartPos = new UnityEngine.Vector2(14.25f, -3.25f);

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();

        switch (gameManager.gameDifficulty)
        {
            case GameDifficulty.Easy:
                Instantiate(enemySpawns[0], enemyStartPos, enemySpawns[0].transform.localRotation);
                break;
            case GameDifficulty.Medium:
                Instantiate(enemySpawns[1], enemyStartPos, enemySpawns[1].transform.localRotation);
                break;
            case GameDifficulty.Hard:
                Instantiate(enemySpawns[2], enemyStartPos, enemySpawns[2].transform.localRotation);
                break;
            default:
                Debug.Log("A game difficulty has not been set at " + gameManager.gameObject.name);
                Debug.Break();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
