using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingArrow : MonoBehaviour
{
    [SerializeField]
    int zDirection;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, zDirection) * Time.deltaTime);
    }
}
