using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeObject : MonoBehaviour
{
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] int SPEED = 4;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        if (ball == null)
            ball = GameObject.FindGameObjectWithTag("Sprikes");
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * SPEED);
    }
    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Wall"|| collision.gameObject.tag == "Ground")
            Flip();
        if (collision.gameObject.tag == "Player")
        {
            ball.GetComponent<ScoreManger>().AddPoints(-2);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
