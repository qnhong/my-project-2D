using Unity.VisualScripting;
using UnityEngine;

public class trigger_coin : MonoBehaviour
{
    public GameObject sound_object;//�ŧi�n������
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);//�I�쪺�ɭ���ܪ���W��
        if (other.name == "player")
        {
            Instantiate(sound_object,transform.position,Quaternion.identity);//�Y�ɲ��ͪ���
            game_manager.instance.GetScore(1);//��������
            Debug.Log(game_manager.gameScore);
            Destroy(gameObject);//�R������ۤv
            
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
}
