using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;
    public float speedMove;
    public float speedRotation;
    public GameObject win, lose;
    
    [HideInInspector]
    public bool deadCheck = false;
    private float health = 15f;
    private Transform enemy;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            float vertical = Input.GetAxis("Vertical");
            float mx = Input.GetAxis("Mouse X");
            if (vertical != 0)
            {
                controller.Move(transform.forward * vertical * speedMove *Time.deltaTime);
                animator.SetBool("IsWalk", true);
            }
            else animator.SetBool("IsWalk", false);
            if (mx != 0)
            { 
                transform.Rotate(transform.up * mx * speedRotation * Time.deltaTime);
            }
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetBool("Hit", true);
                Hit();
            } 
            else if (Input.GetMouseButtonUp(0))
            {
                animator.SetBool("Hit", false);
            }
        }
        controller.Move(Physics.gravity * Time.deltaTime); 
    }

    void FixedUpdate()
    {       
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    void Hit()
    {
        if (enemy != null)
        {
            if (Vector3.Distance (transform.position, enemy.position) < 1.5f)
            {
                enemy.SendMessage("Damage");
            }
        }
        else 
        {
            win.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Level2Button()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Level3Button()
    {
        SceneManager.LoadScene("Level3");
    }

    public void Again1Button()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Again2Button()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Again3Button()
    {
        SceneManager.LoadScene("Level3");
    }

    public void Damage()
    {
        if (health > 0)
        {
            float newHealth = health - 0.5f;
            health = newHealth;
            animator.SetTrigger("GetHit");
            Debug.Log("player" + health);
        }
        else 
        {
            animator.SetTrigger("Dead");
            deadCheck = true;
            lose.SetActive(true);
        }
    }
}
