using Unity.VisualScripting;
using UnityEngine;

public class trigger_coin : MonoBehaviour
{
    public GameObject sound_object;//宣告聲音物件
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);//碰到的時候顯示物件名稱
        if (other.name == "player")
        {
            Instantiate(sound_object,transform.position,Quaternion.identity);//即時產生物件
            game_manager.instance.GetScore(1);//紀錄分數
            Debug.Log(game_manager.gameScore);
            Destroy(gameObject);//刪除物件自己
            
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
}
