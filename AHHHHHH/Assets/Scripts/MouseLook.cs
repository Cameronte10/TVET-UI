using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public enum RotationType
    {
        MouseX, MouseY
    }
    [Header("Rotation Type")]
    public RotationType rotateType = RotationType.MouseX;
    [Space(20)]
    [Range(0, 30)]
    public float sensitivity = 15;
    public float minY = -60, maxY = 60;

    private float rotation;
    // Update is called once per frame
    void Update()
    {
        if (rotateType == RotationType.MouseX)//Look Horiontal
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity * Time.timeScale, 0);
        }
        else//Look up and down
        {
            rotation += Input.GetAxis("Mouse Y") * sensitivity * Time.timeScale;
            rotation = Mathf.Clamp(rotation, minY, maxY);
            transform.localEulerAngles = new Vector3(-rotation, 0, 0) ;
        }
    }
}
