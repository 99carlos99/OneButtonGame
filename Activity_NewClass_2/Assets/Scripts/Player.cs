using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public bool isLeft;
    float speed = 5;

    public GameObject startP;
    public GameObject endP;

    public GameObject menu;

    public int health = 5;
    public int points = 0;

    public Text pointText;
    public Text healthText;

    void Start()
    {

        if (!isLeft)
        {
            transform.position = startP.transform.position;
        }
        else
        {
            transform.position = endP.transform.position;
        }
    }

    void Update()
    {
        if (Input.GetKey("space") && !isLeft)
        {
            transform.position = Vector3.MoveTowards(transform.position, endP.transform.position, speed * Time.deltaTime);
            if (transform.position == endP.transform.position)
            {
                isLeft = true;
                //GetComponent<SpriteRenderer>().flipX = true;
                transform.Rotate(0f, 180f, 0f);
            }
            gameObject.GetComponent<Animator>().SetBool("isMoving", true);

        }

        if (Input.GetKey("space") && isLeft)
        {
            transform.position = Vector3.MoveTowards(transform.position, startP.transform.position, speed * Time.deltaTime);
            if (transform.position == startP.transform.position)
            {
                isLeft = false;
                transform.Rotate(0f, 180f, 0f);
            }
            gameObject.GetComponent<Animator>().SetBool("isMoving", true);
        }

        if (!Input.GetKey("space"))
        {
            gameObject.GetComponent<Animator>().SetBool("isMoving", false);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            menu.SetActive(true);

        }

        if (health > 5)
        {
            health--;
        }
        pointText.text = "Score: " + points.ToString("0");
        healthText.text = "Health: " + health.ToString("0");
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(startP.transform.position, endP.transform.position);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Meteor"))
        {
            health--;
        }

        if (collision.gameObject.CompareTag("Heart"))
        {
            health++;
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            points+=100;
        }

        if (collision.gameObject.CompareTag("RedCoin"))
        {
            points +=200;
        }

        if (collision.gameObject.CompareTag("BlueCoin"))
        {
            points += 200;
        }

    }
}
