using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float dumping;
    [SerializeField] private float maxSpeed;
    
    public Transform target;
    private Vector3 velocity = Vector3.zero;
    private void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        targetPosition.z = transform.position.z;
        if(targetPosition.y > 0)
            targetPosition.y = transform.position.y;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, dumping, maxSpeed);

    }
}
