using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PolicemanFollow : MonoBehaviour
{
    public GameObject Player;
    public float speed = 10;
    public float minDistance;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 lookAt = Player.transform.position;

        lookAt.y = transform.position.y;

        transform.LookAt(lookAt);


        if(Vector3.Distance(transform.position, Player.transform.position) >= minDistance)
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }

        else if(Vector3.Distance(transform.position, Player.transform.position) <= minDistance)
        {
            text.SetActive(true);
        }
    }
}
