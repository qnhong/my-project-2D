using UnityEngine;

public class destroy_itself : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject,1.0f);//�n������1���R��
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
