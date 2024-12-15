using UnityEngine;

public class S1 : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;//宣告Rigidbody2D物件

    public float movespeed = 3.5f;//Unity裡可以修改這個值，但不會修改腳本裡的值

    private Vector2 moveDir;//移動方向(向量變數)=(x,y)

    private Animator m_animator;//宣告animator物件

    private SpriteRenderer m_SpriteRenderer;//宣告SpriteRenderer物件

    public float jump_force=750.0f;//宣告質量變數

    public bool isgrounded=false;//宣告布林變數

    public GameObject grounded_object;//宣告遊戲物件

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Rigidbody2D=GetComponent<Rigidbody2D>();//獲取組件內容
        m_animator= GetComponent<Animator>();// 獲取組件內容
        m_SpriteRenderer= GetComponent<SpriteRenderer>();// 精靈渲染器
    }

    // Update is called once per frame
    void Update()
    {
        m_animator.SetBool("isgrounded",isgrounded);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //m_Rigidbody2D.linearVelocity = new Vector2(movespeed, 0); //velocity已改為linearVelocity
            moveDir.x = movespeed;
            m_animator.SetFloat("Move",1);//設置變數Move的值
            m_SpriteRenderer.flipX = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //m_Rigidbody2D.linearVelocity = new Vector2(-movespeed, 0);
            moveDir.x = -movespeed;
            m_animator.SetFloat("Move", 1);
            m_SpriteRenderer.flipX = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            //m_Rigidbody2D.linearVelocity = Vector2.zero;// 物體速度0
            moveDir = Vector2.zero;
            m_animator.SetFloat("Move", 0);
        }
        if (Input.GetKeyDown(KeyCode.Space)&& isgrounded) { //按下空白鍵與是在地面上
            m_Rigidbody2D.AddForce(Vector2.up * jump_force);
            m_animator.SetTrigger("jump");//設置觸發器
        }
        moveDir.y = m_Rigidbody2D.linearVelocity.y;// y的移動方向=物體的y方向速度

        m_Rigidbody2D.linearVelocity = moveDir;// 用 moveDir 來控制物體的速度


    }
    private void OnCollisionStay2D(Collision2D other)//碰撞停留時，other是其他物體
    {
        if (other.gameObject.CompareTag("grounds"))//檢查碰撞的物體是否標記為 grounds
        {
            foreach (ContactPoint2D element in other.contacts)//other.contacts 是一個包含所有與 other 碰撞物體接觸點的陣列
            {
                if (element.normal.y > 0.25f)//每個接觸點 element 有一個 normal 屬性，它是法線向量（Vector2），表示該接觸點的表面法線的方向。
                {
                    grounded_object=other.gameObject;//紀錄地面物件
                    isgrounded=true;
                    break;
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)//碰撞離開時
    {
        if (other.gameObject == grounded_object)//判斷是否在空中
        {
            grounded_object = null;
            isgrounded= false;
        }
    }
}
