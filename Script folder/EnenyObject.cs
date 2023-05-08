using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnenyObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D Balloon)
    {
        Debug.Log(Balloon.gameObject.tag);
        if (Balloon.gameObject.tag == "Player")
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
