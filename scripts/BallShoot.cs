using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallShoot : MonoBehaviour
{

    public GameObject Ball;
    public Transform SpawnPoint;
    int rotationY,rotationX;

    player_script player;

    public GameObject taptext;
    public GameObject taptext2;
    public int penaltyTries;
    bool gamestart = false;
    // Start is called before the first frame update
    public void Startshoot()
    {
        InvokeRepeating("Shoot", 1f, 3f);
        player = GameObject.FindObjectOfType<player_script>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && !gamestart)
        {
            Startshoot();
            taptext.SetActive(false);
            taptext2.SetActive(false);
            gamestart = true;
        }


        if (player.Lives <= 0)
        {
            Destroy(gameObject);
            gamestart=false;

        }
    }

    public void Shoot()
    {
        SpawnPoint.transform.rotation = Quaternion.identity;
        rotationY = Random.Range(-190,-170);
        rotationX = Random.Range(0, -20);

        SpawnPoint.Rotate(rotationX, rotationY, 0f);

        Instantiate(Ball, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
    }
}
