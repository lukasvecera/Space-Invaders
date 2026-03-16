using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Movement : MonoBehaviour
{
    //public TMP_Text score_text;

    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
    {
        transform.position += transform.right * -speed * Time.deltaTime;
    }

    if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
    {
        transform.position -= transform.right * -speed * Time.deltaTime;
    }


    }


}
