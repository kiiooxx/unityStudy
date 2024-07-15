using UnityEngine;

public class Movement2D : MonoBehaviour
{
    private float   moveSpeed = 5.0f;               //이동 속도
    private Vector3 moveDirection = Vector3.zero;   //이동 방향
    private Rigidbody2D rigid2D;


    private void Awake()
    {
        //게임오브젝트의 컴포넌트에 접근하는 방법 GetComponent<컴포넌트 이름>();
        rigid2D = GetComponent<Rigidbody2D>();
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
        if(x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        //Rigidbody2D 컴포넌트에 있는 속력(velocity) 변수 설정
        rigid2D.velocity = new Vector3(x, y, 0) * moveSpeed;

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
