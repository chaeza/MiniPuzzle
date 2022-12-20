using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentInfo : MonoBehaviour
{
    private enum PresentState
    {
        Bomb,
        Present,
    }
    [SerializeField] private PresentState state;
    [SerializeField] private bool canMove;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject leftPos;
    [SerializeField] private GameObject rightPos;
    [SerializeField] private GameObject targetPos;
    [SerializeField] private PlayerInput PlayerInput;
    [SerializeField] private Rigidbody rigidbody;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        PlayerInput = FindObjectOfType<PlayerInput>();
        PlayerInput.del_PlayerClick = PresentDir;
        if (gameObject.tag == "Present") state = PresentState.Present;
        else if (gameObject.tag == "Bomb") state = PresentState.Bomb;
        else Debug.Log("This Object don't have any tag.");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CheckPoint")
        {
            canMove = true;
        }
    }
    //CheckPoint�� PlayerInput Script���� ȣ�� 
    public void PresentDir(string dir)
    {
        if (dir == "Right") targetPos = rightPos;
        else if (dir == "Left") targetPos = leftPos;
        else Debug.Log("It is not selected value ");
        PresentMove();
    }

    public void PresentMove()
    {
        if (canMove == true)
        {
            //���°� ������ ��� 
            if (state == PresentState.Present)
            {
                Debug.Log("?");
                gameObject.transform.LookAt(targetPos.transform);
                StartCoroutine(Co_PresentMove());
                if (targetPos == rightPos)
                {
                    //UI ���� �÷��ִ� �Լ� ȣ�� 
                    //�Լ� ��¼�� �Է��ϱ� 
                }
            }
            //���°� ��ź�� ���
            else if (state == PresentState.Bomb)
            {
                Debug.Log("?");
                gameObject.transform.LookAt(targetPos.transform);
                StartCoroutine(Co_PresentMove());
                //�̵� ��Ű�� 
                if (targetPos == rightPos)
                {
                    //�Ͻ������� Ű�Է� ���� ����
                    PlayerInput.canClick = false;
                    Invoke("PauseCancle", 1);
                }
            }
        }
    }
    IEnumerator Co_PresentMove()
    {
        int i = 0;
        while (i < 100)
        {
            rigidbody.transform.Translate(Vector3.forward * 0.1f);
            i++;
            yield return null;
        }
        canMove = false;
        yield return null;
    }
    private void PauseCancle() => PlayerInput.canClick = true;

}
