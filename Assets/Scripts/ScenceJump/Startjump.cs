using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Startjump: MonoBehaviour
{
    public Button startButton;
    //当按钮按下时，调用这个方法 
    void Start()
    {
        startButton.onClick.AddListener(StartMenu);
    }



    public Image image_effect;
    public float fadeTime = 1;
    public void StartMenu()
    {

        StartCoroutine(inStart());        
    }
    IEnumerator inStart()
    {   
        Color tempColor = image_effect.color;
        tempColor.a = 0;
        image_effect.color = tempColor;
        while (image_effect.color.a < 1)
        {
            image_effect.color += new Color(0, 0, 0, fadeTime * Time.deltaTime);
            yield return null;
        }   
        SceneManager.LoadScene(2);  

    } 
}