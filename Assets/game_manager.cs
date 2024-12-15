using UnityEngine;
using UnityEngine.UI;

public class game_manager : MonoBehaviour 
{
    //任何繼承自 MonoBehaviour 的類別都能夠使用 Unity 引擎提供的各種功能和生命周期方法
    //（如 Awake()、Start()、Update() 等）。
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static game_manager instance;
    //變數 instance 會是一個 game_manager 類型的參考。
    //這樣就可以用來存放一個 game_manager 類別的實例。
    public static int gameScore = 0;
    public GameObject targetUI;
    public Text targetText;
    void Awake(){
        if (instance == null) { //如果類別還沒有實例
            instance = this; //把當前物件作為實例
        }
    }
    public void GetScore(int value)
    {
        gameScore += value;
        targetText.text=gameScore.ToString();
        if (gameScore >= 3)
        {
            targetUI.SetActive(true);//啟用UI介面
        }
    }

}
