using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public enum EnemyType { Easy, Medium, Hard };
    public EnemyType enemyType;

    public float speed;

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
        // rb2D = GetComponent<Rigidbody2D>();
        switch (enemyType)
        {
            case EnemyType.Easy:
                speed = 7.0f;
            break;
            case EnemyType.Medium:
                speed = 13.0f;
            break;
            case EnemyType.Hard:
                speed = 15.0f;
                stopEnemy = false;
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
            Invoke("HardEnemyMovesAgain", timerStoppingTime);
        }
    }

    void HardEnemyMovesAgain()
    {
        speed *= hardSpeedUp;
        stopEnemy = false;
        timer = 0f;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("DeathZone"))
        {            
            GameManager.Instance.ShowWinning();
            Destroy(gameObject);
        }
    }
}
