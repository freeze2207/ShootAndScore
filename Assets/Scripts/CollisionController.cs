using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionController : MonoBehaviour
{
    bool isCollided = false;
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Bullet" && isCollided == false)
        {
            GamePlayManager.instance.score++;
            GameObject.Find("ScoreText").GetComponent<Text>().text = "Score: " + GamePlayManager.instance.score;
            gameObject.GetComponent<AudioSource>().Play();
            isCollided = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
