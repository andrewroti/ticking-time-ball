using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSoundsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private static BGSoundsScript instance = null;
    public static BGSoundsScript Instance
    {
        get { return instance; }

    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(this.gameObject);
        }
    }
}
