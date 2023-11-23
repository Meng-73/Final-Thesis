using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//scene 2 fader
public class SceneFader : MonoBehaviour
{

    public Image imageEffect;

    public float speed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SceneLoadIn());//start
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
    IEnumerator SceneLoadIn()
    {
        

        Color tempColor = imageEffect.color;
        tempColor.a = 1;
        imageEffect.color = tempColor;

        while (imageEffect.color.a >0)
        {
            imageEffect.color += new Color(0, 0, 0, -speed * Time.deltaTime);

            yield return null;//wait

        }
       
    }

}
