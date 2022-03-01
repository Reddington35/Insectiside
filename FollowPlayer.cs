using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform Target;
    public Vector3 offSet;
    float speed = 0.125f;

    void LateUpdate()
    {
        offSet = new Vector3(0, 350, 0);
        Vector3 pos = Target.position + offSet;
        Vector3 newpos = Vector3.Lerp(transform.position, pos, speed);
        transform.position = newpos;

        transform.LookAt(Target);
    }
}
