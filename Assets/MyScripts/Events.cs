using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//开始菜单，加载场景1，点击按钮
public class Events : MonoBehaviour
{
    public void ReplayGame()
    {

        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
