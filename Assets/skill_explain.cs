using UnityEngine;
using UnityEngine.UI;

public class ButtonTooltip : MonoBehaviour
{
    public Image tooltipImage; // �N���ܼлy Image �����o���ܼƤ�

    private bool isHovering = false;

    void Update()
    {
        // �g�u�˴��A�ˬd���ЬO�_�a���b���s�W
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            // �p�G�˴��쪺����O���s�A��ܴ��ܼлy
            if (hit.collider.gameObject == gameObject)
            {
                tooltipImage.enabled = true;
                isHovering = true;
            }
            else
            {
                // �p�G���ШS���a���b���s�W�A���ô��ܼлy
                if (isHovering)
                {
                    tooltipImage.enabled = false;
                    isHovering = false;
                }
            }
        }
        else
        {
            // �p�G���ШS���a���b���s�W�A���ô��ܼлy
            if (isHovering)
            {
                tooltipImage.enabled = false;
                isHovering = false;
            }
        }
    }
}