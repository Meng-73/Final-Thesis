using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DoorTrigger : MonoBehaviour
{

    public string sceneName = "Scene2";


    public Image imageEffect;

    public float speed = 1;




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            FindObjectOfType<AudioManager>().PlaySound("Transfer");
         


          
     
            StartCoroutine(SceneLoadOut());//start

            
        }
    }



    IEnumerator SceneLoadOut()
    {
       
        Color tempColor = imageEffect.color ;
        tempColor.a = 0;
        imageEffect.color = tempColor;

        while (imageEffect.color.a<1)
        {
            imageEffect.color += new Color(0, 0, 0, speed * Time.deltaTime);

            yield return null;//wait 1 second

        }
        SceneManager.LoadScene(sceneName);//load
        
    }

 

}
