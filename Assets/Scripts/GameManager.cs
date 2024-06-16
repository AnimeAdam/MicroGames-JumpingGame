using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using GameDifficulty = Difficulty.difficulty;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameDifficulty gameDifficulty;

    public static GameManager Instance { get; private set; }

    public bool playerIsDead { get; private set; }

    public TextMeshProUGUI gameOverText;
    public Button backToMenuButton;

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

    public void ShowGameOver()
    {
        gameOverText = FindInActiveObjectByName("GameOverText").GetComponent<TextMeshProUGUI>();
        gameOverText.gameObject.SetActive(true);
        backToMenuButton = FindInActiveObjectByName("BackToMenuButton").GetComponent<Button>();
        backToMenuButton.gameObject.SetActive(true);
    }

    GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
}