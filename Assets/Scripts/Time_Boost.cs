using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time_Boost : MonoBehaviour
{
    private float _speed = Random.Range(3.0f, 7.0f);

    private Player player;

   
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        float _speed = Random.Range(3.0f, 7.0f);
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if(transform.position.y <= -6f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {

            player.AddTime(5);
            Destroy(this.gameObject);
           
        }
    }

}
