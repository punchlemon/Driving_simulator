using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meter : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public Car carScript;
    private float rpm;
    private GameObject rpmArrow;
    private GameObject speedArrow;
    private Vector3 startRotation;
    private Vector3 axis = Vector3.forward;
    private Quaternion rpm_start;
    private Quaternion speed_start;
    private Quaternion id = Quaternion.identity;
    // Start is called before the first frame update
    void Start()
    {
        GameObject car = GameObject.Find("Car");
        rpmArrow = GameObject.Find("rpmArrow");
        speedArrow = GameObject.Find("speedArrow");
        rpm_start = rpmArrow.transform.localRotation;
        speed_start = speedArrow.transform.localRotation;
        carScript = car.GetComponent<Car>();
        startRotation = new Vector3(-81.585f, -90+7.054f, 180);
    }

    // Update is called once per frame
    void Update()
    {
        axleInfos = carScript.axleInfos;
        foreach (AxleInfo axleInfo in axleInfos)
        {
            rpm = Mathf.Min(axleInfo.leftWheel.rpm, axleInfo.rightWheel.rpm);
        }
        rpmRotate(rpm);
    }

    void rpmRotate(float rpm)
    {
        if(rpm < 0) {
            rpm = -rpm;
        }
        Debug.Log(rpm);
        rpmArrow.transform.localRotation = rpm_start;
        speedArrow.transform.localRotation = speed_start;
        rpmArrow.transform.localRotation = Quaternion.AngleAxis(rpm/1000 * 360, axis) * rpmArrow.transform.localRotation;
        speedArrow.transform.localRotation = Quaternion.AngleAxis(rpm/1000 * 360, axis) * speedArrow.transform.localRotation;
    }
}
