using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text _timeRemaining;
    [SerializeField]
    private int timeRemaining = 10;
    [SerializeField]
    private int _lives = 1;
    [SerializeField]
    private bool _shieldActive;
    private int points;
    [SerializeField]
    private Text _score;
    [SerializeField]
    private Text _restart;

    private Spawn_Manager _spawnManager;
    private Player player;
   

    private Coroutine scoreCounter;
    private Coroutine timer;
    private GameManager _gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        scoreCounter = StartCoroutine(Score());
        timer = StartCoroutine(Countdown());        
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        _timeRemaining.text = ("" + timeRemaining);
        _score.text = ("Score: " + points);
        _restart.text = ("");
        
        if(timeRemaining < 0)
        {
            Death();
            _spawnManager.PlayerDeath();
            player.Destroy();
                       
        
        }
        if(_lives < 1)
        {
            Death();
            _spawnManager.PlayerDeath();
            player.Destroy();
           
           
        }
        if(Input.GetKeyDown(KeyCode.W) && timeRemaining < 3 && _shieldActive == true)
        {
            
            timeRemaining = timeRemaining + 3;
            _shieldActive = false;
        }
        
    }
    
    public void TimerUpdate(int newTime)
    {
        timeRemaining = timeRemaining + 5;   
        _timeRemaining.text = ("" + newTime);
    }

    public void Death()
    {
        _timeRemaining.text = ("GAME OVER");
        _restart.text = ("Press SPACE to restart");
        StopCoroutine(scoreCounter);
        StopCoroutine(timer);
        _gameManager.GameOver();
        
        
        
    }
    
    IEnumerator Countdown()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeRemaining = timeRemaining - 1;

        }
        
       
    }
    IEnumerator Score()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            points = points + 1;
        }

                
    }

    public void Damage()
    {
        _lives--;
    }

    public void NoDamage()
    {
        _lives = _lives - 0;
    }
    public void ShieldAcvtive()
    {
        _shieldActive = true;
    }
}
