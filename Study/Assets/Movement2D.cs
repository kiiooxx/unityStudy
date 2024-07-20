using UnityEngine;

public class Movement2D : MonoBehaviour
{
    //private float   moveSpeed = 5.0f;               //�̵� �ӵ�
    //private Vector3 moveDirection = Vector3.zero;   //�̵� ����

    [SerializeField]
    private float speed = 5.0f; //�̵� �ӵ�
    [SerializeField]
    private float jumpForce = 8.0f; //���� �� (Ŭ���� ���� ����)
    private Rigidbody2D rigid2D;
    [HideInInspector]
    public bool isLongJump = false; //���� ����, ���� ���� üũ

    [SerializeField]
    private LayerMask groundLayer;  //�ٴ� üũ�� ���� �浹 ���̾�
    private CapsuleCollider2D capsuleCollider2D;    //������Ʈ�� �浹 ���� ������Ʈ
    private bool isGrounded;    //�ٴ� üũ (�ٴڿ� ������� �� true)
    private Vector3 footPosition;   //���� ��ġ

    [SerializeField]
    private int maxJumpCount = 2;   //���� ��� ������ �� �� �ִ� �ִ� ���� Ƚ��
    private int currentJumpCount = 0;   //���� ������ ���� Ƚ��


    private void Awake()
    {
        //���ӿ�����Ʈ�� ������Ʈ�� �����ϴ� ��� GetComponent<������Ʈ �̸�>();
        rigid2D = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    //public void FixedUpdate()
    //{
    //    //�÷��̾� ������Ʈ�� Collider2D min, center, max ��ġ ����
    //    Bounds bounds = capsuleCollider2D.bounds;
    //    //�÷��̾��� �� ��ġ ����
    //    footPosition = new Vector2(bounds.center.x, bounds.min.y);
    //    //�÷��̾��� �� ��ġ�� ���� �����ϰ�, ���� �ٴڰ� ��������� isGrounded = true
    //    isGrounded = Physics2D.OverlapCircle(footPosition, 0.1f, groundLayer);

    //    //�÷��̾��� ���� ���� ��� �ְ�, y�� �ӵ��� 0�����̸� ���� Ƚ�� �ʱ�ȭ
    //    //velocity.y <= 0�� �߰����� ������ ����Ű�� ������ �������� �ʱ�ȭ�� �Ǿ�
    //    //�ִ� ���� Ƚ���� 2�� �����ϸ� 3������ ������ �����ϰ� �ȴ�
    //    if(isGrounded == true && rigid2D.velocity.y <= 0)
    //    {
    //        currentJumpCount = maxJumpCount;
    //    }


    //    //���� ����, ���� ���� ������ ���� �߷� ���(gravityScale) ���� (Jump up�� ���� ����)
    //    //�߷� ����� ���� if ���� ���� ������ �ǰ�, �߷� ����� ���� else ���� ���� ������ �ȴ�
    //    if (isLongJump && rigid2D.velocity.y > 0)
    //    {
    //        rigid2D.gravityScale = 1.0f;
    //    }
    //    else
    //    {
    //        rigid2D.gravityScale = 2.5f;
    //    }
    //}

    public void Move(float x)
    {
        //x�� �̵��� x * speed��, y�� �̵��� ������ �ӷ� ��(����� �߷�)
        rigid2D.velocity = new Vector2(x * speed, rigid2D.velocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(footPosition, 0.1f);
    }

    public void Jump()
    {
        //if (isGrounded == true)
        if (currentJumpCount > 0)
        {
            //jumpForce�� ũ�⸸ŭ ���� �������� �ӷ� ����
            rigid2D.velocity = Vector2.up * jumpForce;

            //���� Ƚ�� 1 ����
            currentJumpCount--;
        }
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
        if (x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        //Rigidbody2D ������Ʈ�� �ִ� �ӷ�(velocity) ���� ����
        rigid2D.velocity = new Vector3(x, y, 0) * speed;

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
