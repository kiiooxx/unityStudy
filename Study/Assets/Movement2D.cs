using UnityEngine;

public class Movement2D : MonoBehaviour
{
    private float   moveSpeed = 5.0f;               //�̵� �ӵ�
    private Vector3 moveDirection = Vector3.zero;   //�̵� ����
    private Rigidbody2D rigid2D;


    private void Awake()
    {
        //���ӿ�����Ʈ�� ������Ʈ�� �����ϴ� ��� GetComponent<������Ʈ �̸�>();
        rigid2D = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        //Input Ŭ���� : PC, ����� ���� �Է� �޼ҵ�, ���콺 ��ǥ�� ���� ���� ������Ƽ ������ ����
        //Negative left, a : -1
        //Positive right, d : 1
        //Non : 0
        float x = Input.GetAxisRaw("Horizontal");   //�¿� �̵�       
        //Negative down, s : -1
        //Negative up, w : 1
        //Non : 0
        float y = Input.GetAxisRaw("Vertical");     //���Ʒ� �̵�


        //�¿� �̵� �� �̹��� ����
        if(x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        //Rigidbody2D ������Ʈ�� �ִ� �ӷ�(velocity) ���� ����
        rigid2D.velocity = new Vector3(x, y, 0) * moveSpeed;

        //�̵����� ����
        //moveDirection = new Vector3(x, y, 0);

        //���ο� ��ġ = ���� ��ġ + (���� * �ӵ�)
        //transform.position += moveDirection * moveSpeed * Time.deltaTime;


        //���ο� ��ġ = ���� ��ġ + (���� * �ӵ�)
        //(1, 0, 0) => 1 : ���������� �̵�
        //transform.position = transform.position + new Vector3(1, 0, 0) * 1;

        //transform.position += Vector3.right * 1;
        //�� �ڵ�� ���� ���

        //transform.position += Vector3.right * 1 * Time.deltaTime;



    }
}
