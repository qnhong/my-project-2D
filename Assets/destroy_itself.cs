using UnityEngine;

public class destroy_itself : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject,1.0f);//聲音播完1秒後刪除
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
