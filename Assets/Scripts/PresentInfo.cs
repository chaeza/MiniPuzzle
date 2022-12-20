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
    //CheckPoint의 PlayerInput Script에서 호출 
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
            //상태가 선물일 경우 
            if (state == PresentState.Present)
            {
                Debug.Log("?");
                gameObject.transform.LookAt(targetPos.transform);
                StartCoroutine(Co_PresentMove());
                if (targetPos == rightPos)
                {
                    //UI 점수 올려주는 함수 호출 
                    //함수 어쩌록 입력하기 
                }
            }
            //상태가 폭탄일 경우
            else if (state == PresentState.Bomb)
            {
                Debug.Log("?");
                gameObject.transform.LookAt(targetPos.transform);
                StartCoroutine(Co_PresentMove());
                //이동 시키기 
                if (targetPos == rightPos)
                {
                    //일시적으로 키입력 막는 로직
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
