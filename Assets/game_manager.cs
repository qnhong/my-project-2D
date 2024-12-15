using UnityEngine;
using UnityEngine.UI;

public class game_manager : MonoBehaviour 
{
    //�����~�Ӧ� MonoBehaviour �����O������ϥ� Unity �������Ѫ��U�إ\��M�ͩR�P����k
    //�]�p Awake()�BStart()�BUpdate() ���^�C
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static game_manager instance;
    //�ܼ� instance �|�O�@�� game_manager �������ѦҡC
    //�o�˴N�i�H�ΨӦs��@�� game_manager ���O����ҡC
    public static int gameScore = 0;
    public GameObject targetUI;
    public Text targetText;
    void Awake(){
        if (instance == null) { //�p�G���O�٨S�����
            instance = this; //���e����@�����
        }
    }
    public void GetScore(int value)
    {
        gameScore += value;
        targetText.text=gameScore.ToString();
        if (gameScore >= 3)
        {
            targetUI.SetActive(true);//�ҥ�UI����
        }
    }

}
