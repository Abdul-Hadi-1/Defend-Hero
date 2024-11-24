using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class player_script : MonoBehaviour
{
    private float speed = 0.0090f;
    private Touch touch;
    public Transform respawn_point;
    public GameObject ball_prefab;
    public int Score = 0;
    public int Lives;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;

    public GameObject Extralive; 
    public GameObject EDTEXT;
    
   

    // Start is called before the first frame update
    void Start()
    {
        EDTEXT.SetActive(false);
        Extralive.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        
        if (Input.touchCount > 0) 
        {
            touch = Input.GetTouch(0);


            if(touch.phase == TouchPhase.Moved ) 
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speed, transform.position.y, transform.position.z);
            }
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(ball_prefab, respawn_point.position, Quaternion.identity);
        }

        if(Lives <= 0)
        {
            EDTEXT.SetActive(true);
        }
        else
        {
            livesText.text = ": " + Lives;
        }

       scoreText.text = ":"+Score;

        


    }

    private void OnCollisionEnter(Collision collision)
    {
        Score++;
        Extralive.SetActive(false);

        if ((Score % 10 == 0))
        {
            
            Extralive.SetActive(true);
            Lives++;
        }

    }
}
