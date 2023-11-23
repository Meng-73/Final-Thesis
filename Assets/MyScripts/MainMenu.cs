using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//start panel
public class MainMenu : MonoBehaviour
{
    public Image imageEffect;

    public float speed = 1;


    public void PlayGame()
    {
        
        StartCoroutine(SceneLoadOut());//start
    }

    public void QuitGame()
    {
        Application.Quit();

    }

    IEnumerator SceneLoadOut()
    {
        

        Color tempColor = imageEffect.color;
        tempColor.a = 0;
        imageEffect.color = tempColor;

        while (imageEffect.color.a < 1)
        {
            imageEffect.color += new Color(0, 0, 0, speed * Time.deltaTime);

            yield return null;//wait 1 second

        }
        SceneManager.LoadScene("SampleScene");//load
    }

}
