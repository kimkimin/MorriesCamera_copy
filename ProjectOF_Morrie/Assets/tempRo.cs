using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempRo : MonoBehaviour
{
    //public GameObject target, target2;
    Transform getTran;
    public GameObject temp;
    //Quaternion setRotLay, setRotStand;
    public Vector3 setRotLay, setRotStand;
    public Vector3 setRotLay_world, setRotStand_world;
    Vector3 used;
    Quaternion down, up;
    float limit = 0;

    // Start is called before the first frame update
    void Start()
    {/*
        //getTran = temp.transform;
        //getTran.position = transform.position;
        //getTran = GetComponent<Transform>();
        //temp = getTran.eulerAngles;
        setRotStand = getTran.localEulerAngles;
        setRotStand_world = getTran.eulerAngles;

        //getTran.Rotate(new Vector3(-50,0,0), Space.Self);
        setRotLay = getTran.localEulerAngles;
        setRotLay_world = getTran.eulerAngles;
        //temp = getTran.eulerAngles;

        //var temp = target.transform.Rotate(new Vector3(-50, 0, 0), Space.Self);
        //pasteVar = target.transform.localRotation;
        //target2.transform.localRotation = pasteVar;
        
        used = setRotStand;*/

        var temp = transform.localRotation;//.rotation;
        down = temp *= Quaternion.AngleAxis(-50, Vector3.right);
        up = temp;


        //transform.localRotation = Quaternion.Slerp(up, down, Time.deltaTime);
        //transform.localRotation = Quaternion.Slerp(transform.localRotation, down, 0.1f);
        StartCoroutine(lerpRotation());
        //reRot();
    }

    // Update is called once per frame
    void Update()
    {


        //transform.localEulerAngles = setRotLay;
        //transform.localRotation = setRotLay;
        //transform.eulerAngles = temp;

        //transform.localRotation = Quaternion.FromToRotation(setRotLay, used);
        //transform.rotation *= Quaternion.AngleAxis(-50, Vector3.right);
        //transform.RotateAround(transform.position, Vector3.right, Time.deltaTime * 20);
    }

    IEnumerator lerpRotation()
    {
        limit++;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, down, 0.1f);
        print(transform.localRotation + " , " + down);
        yield return new WaitForSeconds(0.05f);
        if(Mathf.Round(transform.localRotation.x *10) > Mathf.Round(down.x * 10))
            StartCoroutine(lerpRotation());
    }


    /*
    IEnumerator reRota()
    {
        transform.rotation *= Quaternion.AngleAxis(-50 * 0.1f, Vector3.right);
        yield return new WaitForSeconds(0.03f);

        print("인스펙터 회전 x : " + GetInspectorRotation(transform.eulerAngles));

        StartCoroutine(reRota());

    }*/

    /*
    float GetInspectorRotation(Vector3 euler)
    {
        float x = euler.x;
        if(Vector3.Dot(transform.right, Vector3.right) >= 0f)
        {
            if(euler.x >= 0f && euler.x <= 90f)
            {
                x = euler.x;
            }
            if(euler.x >= 270f && euler.x <= 360f)
            {
                x = euler.x - 360f;
            }
        }

        if(Vector3.Dot(transform.right, Vector3.right) < 0)
        {
            if(euler.x >= 0f && euler.x <= 90f)
            {
                x = 180 - euler.x;
            }
            if(euler.x >= 270f && euler.x <= 360f)
            {
                x = 180 - euler.x;
            }
        }

        return x;
    }*/

    /*private void OnEnable()
    {
        GridRotate.LayDown += this.RotateLay;
        GridRotate.StandUp += this.RotateStand;
    }
    private void OnDisable()
    {
        GridRotate.LayDown -= this.RotateLay;
        GridRotate.StandUp -= this.RotateStand;
    }
    void RotateLay()
    {
        if(transform.localEulerAngles != setRotLay)
            transform.localEulerAngles = Vector3.MoveTowards(transform.localEulerAngles, setRotLay, Time.deltaTime * GridRotate.gridSpeed);
    }
    void RotateStand()
    {
        if (transform.localEulerAngles != setRotStand)
            transform.localEulerAngles = Vector3.MoveTowards(transform.localEulerAngles, setRotStand, Time.deltaTime * GridRotate.gridSpeed);
    }
    */
}
