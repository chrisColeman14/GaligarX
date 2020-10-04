using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    public float playerSpeed;
    public Vector3 screenBounds;

    [SerializeField]
    private EnemyController enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 10;
        screenBounds = GetScreenBounds();
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds wait = new WaitForSeconds(2);

        while(true)
        {
            float horizontalPosition = Random.Range(-screenBounds.x + .5f, screenBounds.x - .5f);
            Vector2 spawnPosition = new Vector2(horizontalPosition, screenBounds.y);

            Debug.Log("Enemy Prefab Horizontal Spawn Position " + horizontalPosition);
            Debug.Log("Horizontal Limit " + screenBounds.x);

            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            yield return wait;
        }    
    }

    private Vector3 GetScreenBounds()
    {
        Camera mainCamera = Camera.main;
        Vector3 screenVector = new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z);

        return mainCamera.ScreenToWorldPoint(screenVector);        
    }
}
