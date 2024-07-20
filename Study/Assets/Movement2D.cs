using UnityEngine;

public class Movement2D : MonoBehaviour
{
    //private float   moveSpeed = 5.0f;               //이동 속도
    //private Vector3 moveDirection = Vector3.zero;   //이동 방향

    [SerializeField]
    private float speed = 5.0f; //이동 속도
    [SerializeField]
    private float jumpForce = 8.0f; //점프 힘 (클수록 높게 점프)
    private Rigidbody2D rigid2D;
    [HideInInspector]
    public bool isLongJump = false; //낮은 점프, 높은 점프 체크

    [SerializeField]
    private LayerMask groundLayer;  //바닥 체크를 위한 충돌 레이어
    private CapsuleCollider2D capsuleCollider2D;    //오브젝트의 충돌 범위 컴포넌트
    private bool isGrounded;    //바닥 체크 (바닥에 닿아있을 때 true)
    private Vector3 footPosition;   //발의 위치

    [SerializeField]
    private int maxJumpCount = 2;   //땅을 밟기 전까지 할 수 있는 최대 점프 횟수
    private int currentJumpCount = 0;   //현재 가능한 점프 횟수


    private void Awake()
    {
        //게임오브젝트의 컴포넌트에 접근하는 방법 GetComponent<컴포넌트 이름>();
        rigid2D = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    //public void FixedUpdate()
    //{
    //    //플레이어 오브젝트의 Collider2D min, center, max 위치 정보
    //    Bounds bounds = capsuleCollider2D.bounds;
    //    //플레이어의 발 위치 설정
    //    footPosition = new Vector2(bounds.center.x, bounds.min.y);
    //    //플레이어의 발 위치에 원을 생성하고, 원이 바닥과 닿아있으면 isGrounded = true
    //    isGrounded = Physics2D.OverlapCircle(footPosition, 0.1f, groundLayer);

    //    //플레이어의 발이 땅에 닿아 있고, y축 속도가 0이하이면 점프 횟수 초기화
    //    //velocity.y <= 0을 추가하지 않으면 점프키를 누르는 순간에도 초기화가 되어
    //    //최대 점프 횟수를 2로 설정하면 3번까지 점프가 가능하게 된다
    //    if(isGrounded == true && rigid2D.velocity.y <= 0)
    //    {
    //        currentJumpCount = maxJumpCount;
    //    }


    //    //낮은 점프, 높은 점프 구현을 위한 중력 계수(gravityScale) 조절 (Jump up일 때만 적용)
    //    //중력 계수가 낮은 if 문은 높은 점프가 되고, 중력 계수가 높은 else 문은 낮은 점프가 된다
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
        //x축 이동은 x * speed로, y축 이동은 기존의 속력 값(현재는 중력)
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
            //jumpForce의 크기만큼 윗쪽 방향으로 속력 설정
            rigid2D.velocity = Vector2.up * jumpForce;

            //점프 횟수 1 감소
            currentJumpCount--;
        }
    }


    private void Update()
    {
        //Input 클래스 : PC, 모바일 등의 입력 메소드, 마우스 좌표와 같은 각종 프로퍼티 정보를 제공
        //Negative left, a : -1
        //Positive right, d : 1
        //Non : 0
        float x = Input.GetAxisRaw("Horizontal");   //좌우 이동       
        //Negative down, s : -1
        //Negative up, w : 1
        //Non : 0
        float y = Input.GetAxisRaw("Vertical");     //위아래 이동


        //좌우 이동 시 이미지 반전
        if (x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        //Rigidbody2D 컴포넌트에 있는 속력(velocity) 변수 설정
        rigid2D.velocity = new Vector3(x, y, 0) * speed;

        //이동방향 설정
        //moveDirection = new Vector3(x, y, 0);

        //새로운 위치 = 현재 위치 + (방향 * 속도)
        //transform.position += moveDirection * moveSpeed * Time.deltaTime;


        //새로운 위치 = 현재 위치 + (방향 * 속도)
        //(1, 0, 0) => 1 : 오른쪽으로 이동
        //transform.position = transform.position + new Vector3(1, 0, 0) * 1;

        //transform.position += Vector3.right * 1;
        //위 코드와 같은 결과

        //transform.position += Vector3.right * 1 * Time.deltaTime;



    }
}
