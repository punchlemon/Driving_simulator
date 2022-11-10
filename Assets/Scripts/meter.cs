using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meter : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public Car carScript;
    private float rpm;
    private GameObject rpmArrow;
    private Vector3 startRotation;
    // Start is called before the first frame update
    void Start()
    {
        GameObject car = GameObject.Find("Car");
        rpmArrow = GameObject.Find("rpmArrow");
        carScript = car.GetComponent<Car>();
        startRotation = new Vector3(-81.585f, 7.054f, 180);
    }

    // Update is called once per frame
    void Update()
    {
        axleInfos = carScript.axleInfos;
        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                rpm = Mathf.Min(axleInfo.leftWheel.rpm, axleInfo.rightWheel.rpm);
            }
        }
        rpmRotate(rpm);
    }

    void rpmRotate(float rpm)
    {
        rpmArrow.transform.eulerAngles = startRotation + new Vector3(0, 0, rpm);
    }
}
