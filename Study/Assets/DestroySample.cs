using UnityEngine;

public class Destroy : MonoBehaviour
{
    private GameObject playerObject;


    // Start is called before the first frame update
    void Awake()
    {
        //playerObject ���ӿ�����Ʈ�� "PlayerController" ������Ʈ ����
        //Destroy(playerObject.GetComponent<PlayerController>());

        //playerObject ���ӿ�����Ʈ�� ����
        //Destroy(playerObject);

        //playerObject ���ӿ�����Ʈ�� 2�� �ڿ� ����
        //Destroy(playerObject, 0.2f);
    }
}
