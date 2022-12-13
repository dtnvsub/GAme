using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpolateObject : MonoBehaviour
{
    public Transform _trans1;
    public Transform _trans2;

    Vector3 pos1;
    Vector3 pos2;

    Quaternion rot1;
    Quaternion rot2;
    // Start is called before the first frame update
    void Start()
    {
        pos1 = _trans1.position;
        pos2 = _trans2.position;

        rot1 = _trans1.rotation;
        rot2 = _trans2.rotation;
    }

    public float _Speed = 1.0f;
    public bool UseFirst=true;
    float _interpolation = 0.0f;
    // Update is called once per frame
    void Update() 
    {
        if (UseFirst)
        {
            if (_interpolation>0.0f)
            {
                _interpolation -= Time.deltaTime* _Speed;
                if (_interpolation<0.0f)
                {
                    _interpolation = 0.0f;
                }
            }
        }
        else
        {
            if (_interpolation < 1.0f)
            {
                _interpolation += Time.deltaTime* _Speed;
                if (_interpolation > 1.0f)
                {
                    _interpolation = 1.0f;
                }
            }
        }

        transform.position = Vector3.Lerp(pos1,pos2,_interpolation);
        transform.rotation = Quaternion.Lerp(rot1,rot2,_interpolation);


    }
}
