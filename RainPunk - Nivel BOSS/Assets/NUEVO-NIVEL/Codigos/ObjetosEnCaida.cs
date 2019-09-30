using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosEnCaida : MonoBehaviour
{

    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();



      
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0.0f, -3.0f);
        transform.Rotate(0f, 0f, 20f * Time.deltaTime * 20);

    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Recoge")
        {
            transform.position = new Vector2(transform.position.x, 48.195f);
        }
    }
}
