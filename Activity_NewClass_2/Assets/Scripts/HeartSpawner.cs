using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpawner : MonoBehaviour
{
    public GameObject playerX;
    public Player player; 

    float timer;
    public GameObject meteorPreb;

    void Start()
    {
        player = playerX.GetComponent<Player>();
    }

    void Update()
    {
        if (player.health < 5)
        {
            timer += Time.deltaTime;
            float tr = Random.Range(7f, 10f);
            if (timer >= tr)
            {
                float ranPos = Random.Range(-4.5f, 5f);
                Vector3 pos = new Vector3(ranPos, 2.95f, 0);
                timer = 0;
                Instantiate(meteorPreb, pos, Quaternion.identity);
            }
        }

    }
}
