using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private int _lives = 1;
    [SerializeField]
    private int timeLeft = 10;
    [SerializeField]
    private float _jumpSpeed = 100f;
    [SerializeField]
    private bool _zeroGravity = false;
    [SerializeField]
    private bool _shieldActive = false;
    [SerializeField]
    private bool _timeBoost = false;

    private Coroutine _dying;
    private Coroutine _dyingShield;




    private Spawn_Manager _spawnManager;
    private SpriteRenderer _spriteRenderer;
    private UI_Manager _uiManager;
    private GameManager _gameManager;

    private Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-5f, -3.2f, 0);
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        _dying = StartCoroutine(Dying());
        _dyingShield = StartCoroutine(DyingShield());
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

       
        



        Time.timeScale = 1;
        StartCoroutine(LoseTIme());

    }


    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        if(timeLeft < 0)
        {
            _spawnManager.PlayerDeath();
            _uiManager.Death();
            Destroy(this.gameObject);
            StopCoroutine(LoseTIme());
            _gameManager.GameOver();
        }

        if(Input.GetKeyDown(KeyCode.W) && timeLeft < 3 && _shieldActive == true)
        {
            Desperataion();
        }
        
        if(timeLeft < 4 && _shieldActive == false)
        {
            StartCoroutine(Dying());
        }
        if(timeLeft < 4 && _shieldActive == true)
        {
            StartCoroutine(DyingShield());
        }
    }
    IEnumerator LoseTIme()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft = timeLeft - 1;
        }
    }
        
    private void PlayerMovement()
    { 
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        

        if (Input.GetKeyDown(KeyCode.Space)  && transform.position.y < 1.0f)
        {
            rigidbody2d.velocity = Vector2.up * _jumpSpeed;
            rigidbody2d.gravityScale = 25;
            _zeroGravity = false;
        }
        
       
        else if (Input.GetKeyDown(KeyCode.Space) && transform.position.y > 1.5f)
        {
            rigidbody2d.velocity = Vector2.down * _jumpSpeed;
            rigidbody2d.gravityScale = -25f;
            _zeroGravity = true;
        
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rigidbody2d.gravityScale = -25f;
            _zeroGravity = true;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rigidbody2d.gravityScale = 25f;
            _zeroGravity = false;
        }

        if(transform.position.x <= -9.0f)
        {
            transform.position = new Vector3( -8.99f, transform.position.y, 0);
        }

        if(transform.position.x >= 9.0f)
        {
            transform.position = new Vector3(8.99f, transform.position.y, 0);
        }
    }

    public void Damage()
    {
        if(_shieldActive == true)
        {
            _shieldActive = false;
            _spriteRenderer.color = new Color(0, 0, 0);
            
            return;
        }
        if(_shieldActive == false)
        {
            _uiManager.Damage();
        }
        
        _lives--;


        if(_lives < 1)
        {
            _spawnManager.PlayerDeath();
            _uiManager.Death();
            Destroy(this.gameObject);
            _gameManager.GameOver();
        
        }

        

    
    
    }


    public void ShieldActive()
    {
        _shieldActive = true;
        _spriteRenderer.color = new Color(0, 255, 255);
        
    }
    
    

    public void AddTime(int addedTime)
    {
        
        timeLeft += addedTime;
        _uiManager.TimerUpdate(timeLeft);
        

        
    }
    
    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    public void Desperataion()
    {
        _shieldActive = false;
        _spriteRenderer.color = new Color(0, 0, 0);
        timeLeft = timeLeft + 3;
    } 
    IEnumerator Dying()
    {

        while(timeLeft < 4)
        {
            yield return new WaitForSeconds(0.3f);
            _spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.3f);
            _spriteRenderer.color = Color.black;

            if(_shieldActive == true)
            {
                
                _spriteRenderer.color = new Color(0, 255, 255);
                StopCoroutine(_dying);
            }

            
        }

    }
    IEnumerator DyingShield()
    {
        while(timeLeft < 4 && _shieldActive == true)
        {
            yield return new WaitForSeconds(0.3f);
            _spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.3f);
            _spriteRenderer.color = new Color(0, 255, 255);
        }
            if(_shieldActive == false)
            {
            _spriteRenderer.color = Color.black;        
            StopCoroutine(_dyingShield);

            }
    
    }
}
