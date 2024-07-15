using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;

    private void Awake()
    {
        //Instantiate(playerPrefab);
        //Instantiate(GameObject original, Vector3 position, Quaternion rotation);
        //original ���ӿ�����Ʈ(������)�� �����ؼ� �����ϰ�,
        //������ �������� ��ġ�� position����, ȸ���� rotaition���� ����
        //Instantiate(playerPrefab, new Vector3(3, 3, 0), Quaternion.identity);
        //Instantiate(playerPrefab, new Vector3(-1, -2, 0), Quaternion.identity);

        Quaternion rotation = Quaternion.Euler(0, 0, 45);
        Instantiate(playerPrefab, new Vector3(2, 1, 0), rotation);


        //��� ������ ���� ���� �޾Ƽ� �����ϱ�
        GameObject clone = Instantiate(playerPrefab, Vector3.zero, rotation);

        //��� ������ ���� ������Ʈ�� �̸� ����
        clone.name = "Player001";

        //��� ������ ���� ������Ʈ�� ���� ����
        clone.GetComponent<SpriteRenderer>().color = Color.black;

        //��� ������ ���� ������Ʈ�� ��ġ ����
        clone.transform.position = new Vector3(2, 1, 0);

        //ũ�� ����
        clone.transform.localScale = new Vector3(3, 2, 1);
    }
}
