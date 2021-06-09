using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle_Enemy : MonoBehaviour
{
    [SerializeField]
    private float _enemySpeed = 3;
    [SerializeField]
    private int _enemyId;

    private UI_Manager _uiManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        float _enemySpeed = Random.Range(3.0f, 5.0f);
        transform.Translate(Vector3.left * _enemySpeed * Time.deltaTime);

        if(transform.position.x < -10f)
        {
           Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.transform.GetComponent<Player>().Damage();
            
            Destroy(this.gameObject);
        }
            
    }

  
    

}
