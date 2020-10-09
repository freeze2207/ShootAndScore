using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager instance;
    public int score = 0;
    public int ammo = 10;


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }else
        {
            Destroy(this); // destroy other components of same type, so there can be only one
        }

        GameObject.Find("AmmoText").GetComponent<Text>().text = "Ammo: " + instance.ammo;
        GameObject.Find("ScoreText").GetComponent<Text>().text = "Score: " + instance.score;
    }

    // Update is called once per frame
    void Update()
    {
        if(score >= 20)
        {
            SceneManager.LoadScene(2);
        }
        
    }
    
}

