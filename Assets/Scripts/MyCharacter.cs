using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacter: MonoBehaviour
{
    Vector3 _Destination;
    private UnityEngine.AI.NavMeshPath _path;
    List<Vector3> _simplePath = new List<Vector3>();
    public CapsuleCollider _Collider;
    public AudioSource _FootSteps;
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
        if (_simplePath.Count > 0)
        {
            Vector3 RelPos = (transform.position - _simplePath[0]);
            RelPos.y = 0.0f;
            while (_simplePath.Count > 0 && RelPos.magnitude < 1.5f)
            {
                _simplePath.RemoveAt(0);
                if (_simplePath.Count > 0)
                {
                    RelPos = (transform.position - _simplePath[0]);
                    RelPos.y = 0.0f;
                }
            }
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
            if (_FootSteps)
            {
                _FootSteps.volume = 0.3f;
            }
        }
        else
        {
            GetComponent<Animator>().SetFloat("RunSpeed", 0.0f);
            if (_FootSteps)
            {
                _FootSteps.volume = 0.0f;
            }
        }
    }
}