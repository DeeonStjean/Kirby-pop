using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ballooncontrol : MonoBehaviour
{
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] const int SPEED = 3;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] GameObject balloon;
    // Start is called before the first frame update
    void Start()
    {
        if (balloon == null)
            balloon = GameObject.FindGameObjectWithTag("Balloon");
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();

        InvokeRepeating("Grow", 11, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * SPEED);
    }
    private void Grow()
    {
        rigid.transform.localScale = new Vector3(rigid.transform.localScale.x + 0.002f,
            rigid.transform.localScale.x + 0.002f, rigid.transform.localScale.x + 0.002f);


        if (rigid.transform.localScale.x >= 0.50)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Wall")
            Flip();
    }
    private void OnTriggerEnter2D(Collider2D Balloon)
    {
        Debug.Log(Balloon.gameObject.tag);
        if (Balloon.gameObject.tag == "Wall")
            Flip();

        if (Balloon.gameObject.tag == "bluefire")
        {
            if (rigid.transform.localScale.x <= 0.35)
                balloon.GetComponent<ScoreManger>().AddPoints(3);
            if (rigid.transform.localScale.x > 0.35 && rigid.transform.localScale.x <= 0.42)
                balloon.GetComponent<ScoreManger>().AddPoints(2);
            if (rigid.transform.localScale.x > 0.42)
                balloon.GetComponent<ScoreManger>().AddPoints(1);
           
            balloon.GetComponent<ScoreManger>().AdvanceLevel();
        }

    }

}
