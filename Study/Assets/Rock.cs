using System.Collections;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //돌과 부딪힌 오브젝트를 삭제
        Destroy(collision.gameObject);

        //충돌이 일어나면 돌의 색상을 잠깐 변경한다
        StartCoroutine("HitAnimation");
    }

    private IEnumerable HitAnimation()
    {
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        spriteRenderer.color = Color.white;
    }
}
