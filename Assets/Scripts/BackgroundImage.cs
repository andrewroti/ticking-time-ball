using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundImage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(29, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.left * 0.3f * Time.deltaTime);

      
       
         if (transform.position.x <= -29.0f)
        {
            transform.position = new Vector3(29f, 0, 0);
            transform.Translate(Vector3.left * 0.3f * Time.deltaTime);
        }

    }
   
}
