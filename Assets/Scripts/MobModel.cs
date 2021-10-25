using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class MobModel : MonoBehaviour
{
    private MobDescription _description;
    public NavMeshAgent agent;
    public Animator animator;
    private Transform player;
    private bool check;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(findPath());
        StartCoroutine(playerDetect());
    }

    IEnumerator findPath()
    {
        while(true)
        {
            if (check == false)
            {
                agent.SetDestination(player.position);
                animator.SetBool("IsWalk", true);
                yield return new WaitForSeconds(2f);
            }
            else break;
        }
    }

    IEnumerator playerDetect()
    {
        while (true)
        {
            if (check == true) 
            {
                animator.SetBool("Attack", false);
                break; 
            }
            if (Vector3.Distance (transform.position, player.position) < 1.5f)
            {
                animator.SetBool("IsWalk", false);
                animator.SetBool("Attack", true);
                player.SendMessage("Damage");
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

    void Update()
    {
        check =  GameObject.Find("Player").GetComponent<PlayerController>().deadCheck;
    }

    public MobModel(MobDescription description)
    {
        _description = description;
        Instantiate(_description.Pref, new Vector3(0.1f, 0, 7.22f), Quaternion.identity);
    }
}
