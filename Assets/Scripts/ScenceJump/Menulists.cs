using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menulists : MonoBehaviour
{
    public GameObject menuList; //菜单列表
    [SerializeField] private bool menuKeys=true;//菜单按键
    [SerializeField] private AudioSource bgm; //背景音乐
    public Button openButton;             
    public void OpenMenu()//打开菜单按钮
    {
        menuList.SetActive(true);
        menuKeys = false;
        Time.timeScale = 0;
        bgm.Pause();
    }  
    void Start()        
    {
        openButton.onClick.AddListener(OpenMenu);
    }  
    // Update is called once per frame
    void Update()
    {
        if(menuKeys)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                menuList.SetActive(true);
                menuKeys = false;
                Time.timeScale = 0;//游戏暂停
                bgm.Pause();//背景音乐暂停

            }
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            menuList.SetActive(false);
            menuKeys = true;
            Time.timeScale = 1;//游戏继续
            bgm.UnPause();//背景音乐继续
        } 
        

   }
   public void Contitue()//返回按钮
    {
        menuList.SetActive(false);
        menuKeys = true;
        Time.timeScale = 1;
        bgm.UnPause();
    }
    public void Restart()//重新开始按钮
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void Exit()//退出按钮
    {
        Application.Quit();
    }
    
}
