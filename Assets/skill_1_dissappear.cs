using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class skill_1_dissappear : MonoBehaviour
{
    public Animator animator;
    public Button bookButton;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        // ���] entry �O�A�������ʵe
        animator.enabled = false; // �ھ� flag �ҥ�/�T�ΰʵe����
       // bookButton.interactable = false;
    }
    public void start_press()
    {
        // �b�o�̥[�J�A�����s���U�ɭn�����Ʊ�
        // �ҥΫ��s�����ʪ��A
        bookButton.interactable = true;
    }
    public void stop_press()
    {
        bookButton.interactable = false;
    }
    public void turn_animate()
    {
        animator.enabled = true;
    }
     public void turn_on()
    {
        animator.SetInteger("state", 1);
    }
    public void SETACTIVE_false()
    {
        gameObject.SetActive(false);
    }
    public void SETACTIVE_true()
    {
        gameObject.SetActive(true);
    }
    public void turn_off()
    {
        animator.SetInteger("state", 0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
