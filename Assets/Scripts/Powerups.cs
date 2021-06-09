using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    private UI_Manager _uimanager;
    // Start is called before the first frame update
    void Start()
    {
        _uimanager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        float _powerupSpeed = Random.Range(3.0f, 7.0f);
        transform.Translate(Vector3.left * _powerupSpeed * Time.deltaTime);
        if(transform.position.x < -10f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.GetComponent<Player>();
        if(other.tag == "Player")
        {
            other.GetComponent<Player>().ShieldActive();
            _uimanager.ShieldAcvtive();
            Destroy(this.gameObject);
        }
    }

}
