using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public GameObject healthText;
    public float speed;
    public float rotateSpeed;
    public float damageRate;
    public float health;

    public Animator animator;

    float moveSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("IsWalkBool", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("IsWalkBool", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Euler(0, 270, 0);
            animator.SetBool("IsWalkBool", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            animator.SetBool("IsWalkBool", true);
        }
        if (Input.anyKey == false)
        {
            animator.SetBool("IsWalkBool", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("AttackTrigger");
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
            health -= damageRate * Time.deltaTime;
            healthText.GetComponent<Text>().text = "Health: " + health;
        }
        if (health <= 0)
        {
            animator.SetTrigger("DeadTrigger");
        }
    }
}
