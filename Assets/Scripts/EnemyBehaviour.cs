using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public enum EnemyType { Easy, Medium, Hard };
    public EnemyType enemyType;

    public float speed;
    public AudioSource audioSource;

    //Medium enemy
    private const float rotateSpeed = 300f;

    //Hard enemy
    private float timer;
    private const float timerLimitToStop = 1.0f;
    private const float timerStoppingTime = 2.0f;
    private const float hardSpeedUp = 1.6f;
    private bool stopEnemy;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        switch (enemyType)
        {
            case EnemyType.Easy:
                speed = 7.0f;
                PlayEasyAudio();
            break;
            case EnemyType.Medium:
                speed = 13.0f;
                PlayMediumAudio();
            break;
            case EnemyType.Hard:
                speed = 15.0f;
                stopEnemy = false;
                PlayHardStartUpAudio();
            break;
            default:
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.playerIsDead){
            timer += Time.deltaTime;
            SelectEnemyBehaviour();
        }
        else
            audioSource.Stop();
    }

    private void SelectEnemyBehaviour()
    {
        switch (enemyType)
        {
            case EnemyType.Easy:
                EasyEnemy();
                break;
            case EnemyType.Medium:
                MidEnemy();
                break;
            case EnemyType.Hard:
                HardEnemy();
                break;
            default:
                Debug.Log("An enemy wasn't assigned a type at " + gameObject.name);
                Debug.Break();
                break;
        }
    }

    //Enemy will move to the left.
    void EasyEnemy()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.right);
    }

    //Enemy will move to the left while spinnning.
    void MidEnemy()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.left, Space.World);
        transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime, Space.Self);
    }

    //Enemy will move to the left, stop then speed up.
    void HardEnemy()
    {
        if (timer <= timerLimitToStop && !stopEnemy)
            transform.Translate(speed * Time.deltaTime * Vector2.left, Space.World);
        else if (!stopEnemy)
        {
            stopEnemy = true;
            audioSource.Stop();
            Invoke("HardEnemyMovesAgain", timerStoppingTime);
        }
    }

    void HardEnemyMovesAgain()
    {
        PlayHardRunningAudio();
        speed *= hardSpeedUp;
        stopEnemy = false;
        timer = 0f;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("DeathZone"))
        {            
            GameManager.Instance.ShowWinning();
            audioSource.Stop();
            Destroy(gameObject);
        }
    }

    #region Audio

    void PlayEasyAudio()
    {
        audioSource.clip = FindAnyObjectByType<SoundManager>().audioSoundClips[2];
        audioSource.loop = true;
        audioSource.volume = 0.3f;
        audioSource.Play();
    }

    void PlayMediumAudio()
    {
        audioSource.clip = FindAnyObjectByType<SoundManager>().audioSoundClips[3];
        audioSource.loop = true;
        audioSource.volume = 0.3f;
        audioSource.Play();
    }

    void PlayHardStartUpAudio()
    {
        audioSource.clip = FindAnyObjectByType<SoundManager>().audioSoundClips[4];
        audioSource.volume = 0.3f;
        audioSource.Play();
    }

    void PlayHardRunningAudio()
    {
        audioSource.clip = FindAnyObjectByType<SoundManager>().audioSoundClips[5];
        audioSource.loop = true;
        audioSource.volume = 0.3f;
        audioSource.Play();
    }

    #endregion Audio
}
