using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private Animator animater;

    // Start is called before the first frame update
    private void Awake()
    {
        animater = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animater.SetTrigger("isDie");
        }
    }

    public void OnDieEvent()
    {
        Debug.Log("End of Die Animation");
    }
}
