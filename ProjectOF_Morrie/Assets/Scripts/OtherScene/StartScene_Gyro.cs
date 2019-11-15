using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene_Gyro : MonoBehaviour
{
    public GameObject Background;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 m_gyroGravity = Input.gyro.gravity;
        Vector3 newPosValue = new Vector3(-m_gyroGravity.x * speed, 0,0);
        Background.transform.localPosition = newPosValue;
        //Background.transform.position = newPosValue;
        
    }
}
