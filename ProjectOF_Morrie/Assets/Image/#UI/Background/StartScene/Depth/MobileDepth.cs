using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 휴대폰의 기울기를 가져와서
/// </summary>
public class MobileDepth : MonoBehaviour
{
    //public Text textRot, textAcc;
    public List<GameObject> moveable;
    float remapped;

    List<GameObject> frontObj = new List<GameObject>();
    List<GameObject> backObj = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
        print(Input.gyro.enabled);

        for (int i = 0; i < moveable.Count; i++)
        {
            if (i < 11) backObj.Add(moveable[i]);
            else frontObj.Add(moveable[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        print("자이로 스코프 가속 : " + Input.gyro.userAcceleration);
        Vector3 m_gyroRot = Input.gyro.gravity;
        //textRot.text = m_gyroRot.ToString();
        //textAcc.text = Input.gyro.userAcceleration.ToString();

        for (int i = 0; i < backObj.Count; i++)
        {
            backObj[i].transform.position = new Vector3(-m_gyroRot.x * 10f, moveable[i].transform.position.y, moveable[i].transform.position.z);
        }

        for (int i = 0; i < frontObj.Count; i++)
        {
            frontObj[i].transform.position = new Vector3(m_gyroRot.x * 10f, moveable[i].transform.position.y, moveable[i].transform.position.z);
        }
    }
}
