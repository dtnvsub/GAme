using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacter: MonoBehaviour
{
    Vector3 _Destination;
    private UnityEngine.AI.NavMeshPath _path;
    List<Vector3> _simplePath = new List<Vector3>();
    public CapsuleCollider _Collider;
    void Start()
    {
        _Destination = transform.position;
        _path = new UnityEngine.AI.NavMeshPath();
    }
    public void SetTarget(Vector3 TargetPos)
    {
        _Destination= TargetPos;

        bool foundPath = UnityEngine.AI.NavMesh.CalculatePath(transform.position, TargetPos, UnityEngine.AI.NavMesh.AllAreas, _path);
        _simplePath.Clear();
        for (int i = 0; i < _path.corners.Length; i++)
        {
            _simplePath.Add(_path.corners[i]);
        }
    }
    void Update()
    {
        Vector3 MoveDirection = Vector3.zero;
        while (_simplePath.Count > 0 && (transform.position - _simplePath[0]).magnitude < 0.5f)
        {
            _simplePath.RemoveAt(0);
        }

        if (_simplePath.Count > 0)
        {
            MoveDirection = _simplePath[0] - transform.position;
        }

        if (MoveDirection.magnitude > 0.5f)
        {
            MoveDirection.Normalize();
            transform.rotation = Quaternion.LookRotation(MoveDirection);

            GetComponent<Animator>().SetFloat("RunSpeed", 2.0f);
        }
        else
        {
            GetComponent<Animator>().SetFloat("RunSpeed", 0.0f);
        }
    }
}