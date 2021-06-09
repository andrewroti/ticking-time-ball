using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject _trianglePrefab;
    [SerializeField]
    private GameObject _bigTriangle;
    [SerializeField]
    private GameObject _upsideDownTriangle;
    [SerializeField]
    private GameObject _upsideDownBigTriangle;
    [SerializeField]
    private GameObject _shieldPowerUp;
    [SerializeField]
    private GameObject _timeBoost;
    [SerializeField]
    private GameObject _spawnContainer;
    [SerializeField]
    private GameObject[] _enemyType;
    private bool _stopSpawning = false;
   [SerializeField]
    private float _enemySpeed = 3f;
    private Triangle_Enemy _triangleEnemy;

    
    
    // Start is called before the first frame update
    void Start()
    {
       
        StartCoroutine(EnemyTriangle());
        StartCoroutine(UpsideDown());
        StartCoroutine(PoweUpSpawn());
        StartCoroutine(TimeBoostSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemyTriangle()
    {
        while (_stopSpawning == false)
        {
            GameObject newEnemy = Instantiate(_enemyType[Random.Range(0, 2)], new Vector3(13.0f, -2.6f, 0), Quaternion.identity);
            newEnemy.transform.parent = _spawnContainer.transform;
            yield return new WaitForSeconds(Random.Range(3.0f, 5.0f));
        }
    }
    IEnumerator UpsideDown()
    { 
        while (_stopSpawning == false)
        {
            yield return new WaitForSeconds(Random.Range(5.0f, 7.0f));
            GameObject newEnemy = Instantiate(_enemyType[Random.Range(2, 4)], new Vector3(13.0f, 4.5f, 0), Quaternion.identity);
            newEnemy.transform.parent = _spawnContainer.transform;
          
        }

      
    }

    IEnumerator PoweUpSpawn()
    {
        while(_stopSpawning == false)
        {
            float randomY = Random.Range(-3.5f, 3.5f);
            GameObject newPowerup = Instantiate(_shieldPowerUp, new Vector3(13.0f, randomY, 0), Quaternion.identity);
            newPowerup.transform.parent = _spawnContainer.transform;
            yield return new WaitForSeconds(10.0f);
        }
    }

    IEnumerator TimeBoostSpawn()
    {
        while(_stopSpawning == false)
        {
            yield return new WaitForSeconds(Random.Range(4.0f, 6.0f));
            float randomX = Random.Range(-8.6f, 8.6f);
            GameObject newPowerup = Instantiate(_timeBoost, new Vector3(randomX, 6, 0), Quaternion.identity);
            newPowerup.transform.parent = _spawnContainer.transform;
           
        }
    }
    
    public void PlayerDeath()
    {
        _stopSpawning = true;
        Destroy(this.gameObject);
        Destroy(_spawnContainer.gameObject);
    }

}
