using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//scene 1 robot observe
public class NpcObserver : MonoBehaviour
{
    public GameObject gameOverPanel;

    public static bool gameOver;



    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
    }



    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameOver = true;

            FindObjectOfType<AudioManager>().PlaySound("GameOver");
            //play game over sound
        }
    }



    











    

    
}
