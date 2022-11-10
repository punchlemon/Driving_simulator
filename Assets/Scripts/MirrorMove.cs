using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorMove : MonoBehaviour
{
    public GameObject PlayerCamera;
    public GameObject MirrorCamera;
    // Start is called before the first frame update
    void Start()
    {
        PlayerCamera = GameObject.Find("Main Camera");
        MirrorCamera = transform.Find("Mirror Camera").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 M = transform.position;
        Vector3 Pc = PlayerCamera.transform.position;
        Vector3 isNormal = transform.up;
        Vector3 isDirection = M - Pc;
        Vector3 Mc = Pc + isDirection - Vector3.Reflect(isDirection, isNormal);
        MirrorCamera.transform.position = Mc;
        MirrorCamera.transform.forward = isNormal * 2 + PlayerCamera.transform.forward;
    }
}
