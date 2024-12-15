using UnityEngine;

public class S1 : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;//�ŧiRigidbody2D����

    public float movespeed = 3.5f;//Unity�̥i�H�ק�o�ӭȡA�����|�ק�}���̪���

    private Vector2 moveDir;//���ʤ�V(�V�q�ܼ�)=(x,y)

    private Animator m_animator;//�ŧianimator����

    private SpriteRenderer m_SpriteRenderer;//�ŧiSpriteRenderer����

    public float jump_force=750.0f;//�ŧi��q�ܼ�

    public bool isgrounded=false;//�ŧi���L�ܼ�

    public GameObject grounded_object;//�ŧi�C������

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Rigidbody2D=GetComponent<Rigidbody2D>();//����ե󤺮e
        m_animator= GetComponent<Animator>();// ����ե󤺮e
        m_SpriteRenderer= GetComponent<SpriteRenderer>();// ���F��V��
    }

    // Update is called once per frame
    void Update()
    {
        m_animator.SetBool("isgrounded",isgrounded);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //m_Rigidbody2D.linearVelocity = new Vector2(movespeed, 0); //velocity�w�אּlinearVelocity
            moveDir.x = movespeed;
            m_animator.SetFloat("Move",1);//�]�m�ܼ�Move����
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
            //m_Rigidbody2D.linearVelocity = Vector2.zero;// ����t��0
            moveDir = Vector2.zero;
            m_animator.SetFloat("Move", 0);
        }
        if (Input.GetKeyDown(KeyCode.Space)&& isgrounded) { //���U�ť���P�O�b�a���W
            m_Rigidbody2D.AddForce(Vector2.up * jump_force);
            m_animator.SetTrigger("jump");//�]�mĲ�o��
        }
        moveDir.y = m_Rigidbody2D.linearVelocity.y;// y�����ʤ�V=���骺y��V�t��

        m_Rigidbody2D.linearVelocity = moveDir;// �� moveDir �ӱ���骺�t��


    }
    private void OnCollisionStay2D(Collision2D other)//�I�����d�ɡAother�O��L����
    {
        if (other.gameObject.CompareTag("grounds"))//�ˬd�I��������O�_�аO�� grounds
        {
            foreach (ContactPoint2D element in other.contacts)//other.contacts �O�@�ӥ]�t�Ҧ��P other �I�����鱵Ĳ�I���}�C
            {
                if (element.normal.y > 0.25f)//�C�ӱ�Ĳ�I element ���@�� normal �ݩʡA���O�k�u�V�q�]Vector2�^�A��ܸӱ�Ĳ�I�����k�u����V�C
                {
                    grounded_object=other.gameObject;//�����a������
                    isgrounded=true;
                    break;
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)//�I�����}��
    {
        if (other.gameObject == grounded_object)//�P�_�O�_�b�Ť�
        {
            grounded_object = null;
            isgrounded= false;
        }
    }
}
