using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    public int force;
    player_script player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        force = Random.Range(20, 30);
        rb.AddForce(transform.forward * force, ForceMode.Impulse);

        Destroy(gameObject, 3f);
        player = GameObject.FindObjectOfType<player_script>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Goal"))
        {
            player.Lives--;
        }
    }
}
