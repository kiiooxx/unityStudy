using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movement2D movement2D;

    void Awake()
    {
        movement2D = GetComponent<Movement2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //left or a = -1 / right or d = 1
        float x = Input.GetAxisRaw("Horizontal");

        //�¿� �̵� ���� ����
        movement2D.Move(x);

        //�÷��̾� ���� (�����̽� Ű�� ������ ����)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement2D.Jump();
        }

        //�����̽� Ű�� ������ ������ isLongJump = true
        if (Input.GetKey(KeyCode.Space))
        {
            movement2D.isLongJump = true;
        }
        //�����̽� Ű�� ���� isLongJump = false
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            movement2D.isLongJump = false;
        }
    }
}
