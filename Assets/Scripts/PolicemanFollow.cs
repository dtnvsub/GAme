using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PolicemanFollow : MonoBehaviour
{
    public GameObject Player;
    public float speed = 10;
    public float minDistance;
    public GameObject text;
    public MyCharacter CharController;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //float _TimeSlice = 1.0f;
    // Update is called once per frame
    void Update()
    {
        //_TimeSlice -= Time.deltaTime;
        //if (_TimeSlice < 0.0f)
        //{
          //  _TimeSlice = 1.0f;
        CharController.SetTarget(Player.transform.position);
        Vector3 RelativePosition = Player.transform.position - transform.position;
        if (RelativePosition.magnitude<1.5f)
        {
            SceneManager.LoadScene("GameOver");
        }
        //}
        //Vector3 lookAt = Player.transform.position;

            //lookAt.y = transform.position.y;

            //transform.LookAt(lookAt);


            //if(Vector3.Distance(transform.position, Player.transform.position) >= minDistance)
            //{
            //    transform.position += transform.forward * Time.deltaTime * speed;
            //}

            //else if(Vector3.Distance(transform.position, Player.transform.position) <= minDistance)
            //{
            //    text.SetActive(true);
            //}
    }
}
