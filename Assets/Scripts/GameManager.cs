using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameDifficulty = Difficulty.difficulty;

public class GameManager : MonoBehaviour
{
    public GameDifficulty gameDifficulty;

    public static GameManager Instance { get; private set; }

    public bool playerIsDead { get; private set; }

    private void Awake()
    {
        playerIsDead = false;

        if (Instance != null) {
            Destroy(gameObject);
            return; }
            
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDied()
    {
        playerIsDead = true;
    }

    void StartGame()
    {
        playerIsDead = false;
    }
}