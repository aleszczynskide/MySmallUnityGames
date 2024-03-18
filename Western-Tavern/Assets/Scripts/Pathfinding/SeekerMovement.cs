using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class SeekerMovement : MonoBehaviour
{
    public GameObject Customer;
    public Transform PlayerToFollow;
    public float MoveSpeed = 5f;

    private Pathfinding Pathfinding;
    private GameManager GameManagerScript;
    private Transform Seeker;
    public bool Movement = true;


    private int PathIndex = 0;

    private void Start()
    {
        GameObject GameManager = GameObject.Find("GameManager");
        if (GameManager != null)
        {
            Pathfinding = GameManager.GetComponent<Pathfinding>();
        }

        Seeker = transform;
    }

    private void Update()
    {
        if (Movement)
        {
            if (Pathfinding != null && PlayerToFollow != null)
            {
                Vector2 seekerPosition = Seeker.position;
                Vector2 targetPosition = PlayerToFollow.position;

                Pathfinding.FindPath(seekerPosition, targetPosition);
                FollowPath();
            }
        }
        Vector3 CurrentPositionCustomer = transform.position;
        Vector3 TargetPosition = PlayerToFollow.position;
        float CustomerDistance = Vector3.Distance(CurrentPositionCustomer, TargetPosition);
        if (CustomerDistance <= 0.5f)
        {
            Customer.GetComponent<Customer>().Ordering();
            Movement = false;
        }
    }
    private void FollowPath()
    {
        if (Pathfinding.Grid != null && Pathfinding.Grid.path != null && Pathfinding.Grid.path.Count > 0)
        {
            if (PathIndex < Pathfinding.Grid.path.Count)
            {
                Node targetNode = Pathfinding.Grid.path[PathIndex];
                Vector2 targetPosition = targetNode.worldPosition;

                Vector2 moveDir = (targetPosition - (Vector2)Seeker.position).normalized;
                Vector2 moveAmount = moveDir * Time.deltaTime * MoveSpeed;

                Seeker.position += (Vector3)moveAmount;

                float distanceToTarget = Vector2.Distance(Seeker.position, targetPosition);
                if (distanceToTarget < Pathfinding.Grid.nodeRadius)
                {
                    PathIndex++;
                }
            }
        }
    }
}
