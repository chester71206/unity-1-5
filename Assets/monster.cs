using UnityEngine;
using System.Collections;

public class grabberscript : MonoBehaviour
{
	private Animator animator;
	private float attackInterval = 3.75f; 
	private bool isAttacking = false;
    public GameObject bomb;
    public float throwForceLeft = 10f; 
    public float throwForceUp = 10f;
    public int bombsize = 5;
    public Transform playerTransform;
   //public GameObject healcircle;
    public count_score monster_life_change;
    //public int throwup_min=5;
    //public int throwup_max=15;
    //public int throwleft_min=5;
   // public int throwleft_max=15;
    public bool heal_or_not = false;
    public ParticleSystem laserParticleSystem; // �ɤl�t��

    //�s��
    public Vector3 targetPosition=new Vector3(11.6f,5.3f,0f); // �A�n���ʨ쪺�ؼЦ�m��Transform
    public float movementSpeed = 10.0f; // ���ʳt��
    private bool isMoving = false;
    private Vector2 initialPosition;
    private float startTime;
    private float journeyLength;

    // Use this for initialization
    void Start()
	{
		animator = GetComponent<Animator>();
        //  rb = GetComponent<Rigidbody2D>();

       // InvokeRepeating("heallife", 30f, 30f);
        InvokeRepeating("Attack", 0, attackInterval);

        //�s��
        initialPosition = transform.position;
        animator.SetInteger("state", 0);


    }
    void Update()
    {
        if (isMoving)
        {
            float distanceCovered = (Time.time - startTime) * movementSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;
            transform.position = Vector2.Lerp(initialPosition, targetPosition, fractionOfJourney);

            if (fractionOfJourney >= 1.0f)
            {
                transform.position = targetPosition;
                isMoving = false;
            }
        }
    }
    /*public void heallife()
    {
        if(heal_or_not)
        {
            monster_life_change.plus_monster_life();
            healcircle.SetActive(true);
            StartCoroutine(wait_for_heal());
        }
       
    }*/
    /*IEnumerator wait_for_heal()
    {
        yield return new WaitForSeconds(3f);
        healcircle.SetActive(false) ;
    }*/
    // Update is called once per frame
    private void Attack()
    {


        Vector3 spawnPosition = this.transform.position;
        Vector3 direction = (playerTransform.position - spawnPosition).normalized;

        // �ͦ��E��
        ParticleSystem newLaserParticles = Instantiate(laserParticleSystem, spawnPosition, Quaternion.identity);
        // �]�w�ɤl�t�Ϊ��t�פ�V�]�ϲɤl���u�g�V���a�^
        ParticleSystem.VelocityOverLifetimeModule velocity = newLaserParticles.velocityOverLifetime;
        velocity.enabled = true; // �ҥγt���ܤ�
        velocity.x = direction.x * 10f; // �]�m x ��V�t��
        velocity.y = direction.y * 10f; // �]�m y ��V�t��
        velocity.z = direction.z * 10f; // �]�m z ��V�t��

        // ����ɤl�t��
        newLaserParticles.Play();

        // �R���ɤl�t�ΡA�o�̨ϥ�3��
        Destroy(newLaserParticles.gameObject, 3f);

        // �R���ɤl�t�ΡA�o�̨ϥ�3��
        // Destroy(newLaserParticles.gameObject, 3f);
        /*GameObject newBomb = Instantiate(bomb, this.transform.position, Quaternion.identity); // �b this ��m�Ы� bomb
        newBomb.SetActive(true);
        Vector3 direction = (playerTransform.position - this.transform.position).normalized; // �p��¦V���a����V
        newBomb.GetComponent<Rigidbody2D>().velocity = direction * 50f; // �]�m bomb ���t��

        Destroy(newBomb, 3f); // �@�q�ɶ���R�� bomb*/

        /*if (!isAttacking)
        {
            animator.SetInteger("state", 1);
           // Debug.Log("1");
            isAttacking = true;
           // StartCoroutine(ResetAttack());
        }*/
    }

    /*private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(1.25f);
        ThrowBomb();
       // Debug.Log("2");
        animator.SetInteger("state", 0);
        isAttacking = false;
    }*/

    /*void ThrowBomb()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, 5, 0); // �s���ͦ���m
       // Debug.Log("3");
        for (int i = 0; i < bombsize; i++)
        { 
            GameObject newBomb = Instantiate(bomb, spawnPosition, Quaternion.identity);
            newBomb.SetActive(true);
            Rigidbody2D rb = newBomb.GetComponent<Rigidbody2D>();
             Vector2 throwDirection = new Vector2(-1, 1).normalized;
             throwForceUp = Random.Range(throwup_min, throwup_max);
             throwForceLeft = Random.Range(throwleft_min, throwleft_max);
            throwDirection.x *= throwForceLeft;
             throwDirection.y *= throwForceUp;
             rb.AddForce(throwDirection, ForceMode2D.Impulse);

        }
       

    }*/


}