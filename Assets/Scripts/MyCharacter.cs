using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacter: MonoBehaviour
{
 //a variable to hold the current destination of the character
    Vector3 _Destination;
    // Start is called before the first frame update
    void Start()
    {
    //when we start, set the destination to whatever the current position is
    _Destination = transform.position;
    }
    //a function to set the target desitnation of the character
    public void SetTarget(Vector3 TargetPos)
    {
    _Destination = TargetPos;
    }
    // Update is called once per frame
    void Update()
    {
    //when updating, work out the direction we need to move in
    Vector3 MoveDirection = _Destination- transform.position;
    //if the destination is a reasonable distance away, update the characters rotation to point in this direction
    if (MoveDirection.magnitude > 0.5f)
    {
    MoveDirection.Normalize();
    transform.rotation = Quaternion.LookRotation(MoveDirection);
    //set a variable in the animation controller 
    GetComponent<Animator>().SetFloat("WalkSpeed", 2.0f);
    }
    else
    {
    //set a variable in the animation controller
    GetComponent<Animator>().SetFloat("WalkSpeed", 0.0f);
    }
    }
}