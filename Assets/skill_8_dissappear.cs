using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_8_dissappear : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        // ���] entry �O�A�������ʵe
        animator.enabled = false; // �ھ� flag �ҥ�/�T�ΰʵe����
    }
    public void turn_animate()
    {
        animator.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
