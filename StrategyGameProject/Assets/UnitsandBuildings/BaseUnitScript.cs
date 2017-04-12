using UnityEngine;
using System.Collections;

public class BaseUnitScript : MonoBehaviour {

    Vector3 targetToMoveTo;
    Rigidbody rb;
    float speed;
    public int team;
    bool isAttacking;
    bool isBuilding;
    GameObject targetForAttack;
    
    int health;

    public GameObject testBuildingRef;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        targetToMoveTo = gameObject.transform.position;
        speed = 100.0f;
        rb.drag = 20.0f;
        isAttacking = false;
        team = Random.Range(1, 2);
        health = 10;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 positiveInference = new Vector3(0.5f, 0.5f, 0.5f);
        Vector3 negativeInference = new Vector3(-0.5f, -0.5f, -0.5f);

        Vector3 position = gameObject.transform.position;

        if(Input.GetKeyDown(KeyCode.B))
        {
            if(isBuilding == false)
            {
                isBuilding = true;
            }
            else if(isBuilding == true)
            {
                isBuilding = false;
            }
        }

        if (position.x > (targetToMoveTo.x + positiveInference.x) ||
            position.y > (targetToMoveTo.y + positiveInference.y) ||
            position.z > (targetToMoveTo.z + positiveInference.z) ||
            position.x < (targetToMoveTo.x + negativeInference.x) ||
            position.y < (targetToMoveTo.y + negativeInference.y) ||
            position.z < (targetToMoveTo.z + negativeInference.z))
        {
            Debug.Log("Move");
            Vector3 direction = targetToMoveTo - position;
            rb.AddRelativeForce(direction.normalized * speed, ForceMode.Force);
        }

        if(isAttacking == true)
        {
            if(position.x > (targetForAttack.transform.position.x + positiveInference.x + 1.0f) ||
            position.y > (targetForAttack.transform.position.y + positiveInference.y + 1.0f) ||
            position.z > (targetForAttack.transform.position.z + positiveInference.z + 1.0f) ||
            position.x < (targetForAttack.transform.position.x + negativeInference.x - 1.0f) ||
            position.y < (targetForAttack.transform.position.y + negativeInference.y - 1.0f) ||
            position.z < (targetForAttack.transform.position.z + negativeInference.z - 1.0f))
            {
                Debug.Log("Move");
                Vector3 direction = targetForAttack.transform.position - position;
                rb.AddRelativeForce(direction.normalized * speed, ForceMode.Force);
            }
            else
            {
                Debug.Log("Attack");
                InflictDamage();
            }
        }

        if(isBuilding == true)
        {
            
            if (position.x > (targetToMoveTo.x + positiveInference.x + 1.0f) ||
                position.y > (targetToMoveTo.y + positiveInference.y + 1.0f) ||
                position.z > (targetToMoveTo.z + positiveInference.z + 1.0f) ||
                position.x < (targetToMoveTo.x + negativeInference.x - 1.0f) ||
                position.y < (targetToMoveTo.y + negativeInference.y - 1.0f) ||
                position.z < (targetToMoveTo.z + negativeInference.z - 1.0f))
                {
                    Debug.Log("Move");
                    Vector3 direction = targetForAttack.transform.position - position;
                    rb.AddRelativeForce(direction.normalized * speed, ForceMode.Force);
                }
                else
                {
                    Debug.Log("Build");
                    
                }
        }
	}

    public void Move(Vector3 Location)
    {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Location);
        if (Physics.Raycast(ray, out hit))
        {
            targetToMoveTo = hit.point;
            
        }

        //targetToMoveTo.y = gameObject.transform.position.y;

        //rb.MovePosition(targetToMoveTo);

    }

    public void Attack(GameObject target)
    {
        targetForAttack = target;
        Move(target.transform.position);
        isAttacking = true;
    }

    public void InflictDamage()
    {
        targetForAttack.GetComponent<BaseUnitScript>().TakeDamage();
    }

    public void TakeDamage()
    {
        health = health - 1;

        if(health == 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(this);
    }
}
