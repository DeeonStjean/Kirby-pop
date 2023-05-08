using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float Speed = 4.5f;

    private void Update()
    {
        transform.position += transform.right * Time.deltaTime * Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Balloon")
        {
            Destroy(collision.gameObject);
        }
            Destroy(gameObject);
    }
}
