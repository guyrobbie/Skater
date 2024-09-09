using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class spinning : MonoBehaviour
{
    private int cnt = 0;
    public float xAngle, yAngle, zAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

            transform.Rotate(xAngle, yAngle, zAngle, Space.World);
        
    }
}
