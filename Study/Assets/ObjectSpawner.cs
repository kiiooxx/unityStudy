using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;

    private void Awake()
    {
        //Instantiate(playerPrefab);
        //Instantiate(GameObject original, Vector3 position, Quaternion rotation);
        //original 게임오브젝트(프리팹)를 복제해서 생성하고,
        //생성된 복제본의 위치를 position으로, 회전을 rotaition으로 설정
        //Instantiate(playerPrefab, new Vector3(3, 3, 0), Quaternion.identity);
        //Instantiate(playerPrefab, new Vector3(-1, -2, 0), Quaternion.identity);

        Quaternion rotation = Quaternion.Euler(0, 0, 45);
        Instantiate(playerPrefab, new Vector3(2, 1, 0), rotation);


        //방금 생성된 복제 정보 받아서 설정하기
        GameObject clone = Instantiate(playerPrefab, Vector3.zero, rotation);

        //방금 생성된 게임 오브젝트의 이름 변경
        clone.name = "Player001";

        //방금 생성된 게임 오브젝트의 색상 변경
        clone.GetComponent<SpriteRenderer>().color = Color.black;

        //방금 생성된 게임 오브젝트의 위치 변경
        clone.transform.position = new Vector3(2, 1, 0);

        //크기 변경
        clone.transform.localScale = new Vector3(3, 2, 1);
    }
}
