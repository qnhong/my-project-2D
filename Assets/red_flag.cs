using UnityEngine;

public class red_flag : MonoBehaviour
{
    public GameObject[] active_object;//宣告一個陣列
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(active_object.Length);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "player")
        {
            for (int i = 0; i < active_object.Length; i++)
            {
                Debug.Log(i);
                active_object[i].SetActive(true);//SetActive(true):啟用(顯示)物件
            }
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
