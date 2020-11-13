using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowPath : MonoBehaviour
{
    public enum MovementType
    {
        MoveTowards,
        LerpTowards
    }

    public MovementType Type = MovementType.MoveTowards; 
    public MovementPath MyPath; 
    public float Speed = 1; 
    public float MaxDistanceToGoal = .1f;
    
    private IEnumerator<Transform> pointInPath;

    public void Start()
    {
        if (MyPath == null)
        {
            return;
        }
        
        pointInPath = MyPath.GetNextPathPoint();
        pointInPath.MoveNext();

        if (pointInPath.Current == null)
        {
            return; 
        }
        transform.position = pointInPath.Current.position;
    }
    
    public void Update()
    {
        if (pointInPath == null || pointInPath.Current == null)
        {
            return; 
        }

        if (Type == MovementType.MoveTowards) 
        {
            transform.position = Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * Speed);
        }
        else if (Type == MovementType.LerpTowards) 
        {
            transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position, Time.deltaTime * Speed);
        }

        var distanceSquared = (transform.position - pointInPath.Current.position).sqrMagnitude;
        if (distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal) 
        {
            pointInPath.MoveNext(); 
        }
    }
}
