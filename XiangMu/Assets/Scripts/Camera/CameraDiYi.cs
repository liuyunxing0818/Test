using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDiYi : MonoBehaviour
{
    // 用于控制前后移动速度
    public float moveSpeed = 5f;

    // 用于控制视角旋转速度
    public float lookSpeed = 2f;

    // 限制垂直视角旋转范围
    public float verticalLookLimit = 80f;

    // 当前垂直旋转角度
    private float verticalRotation = 0f;

    void Update()
    {
        // 获取垂直输入（W/S 或 Up/Down 键）
        float verticalInput = Input.GetAxis("Vertical");

        // 根据输入前后移动摄像机
        transform.Translate(Vector3.forward * verticalInput * moveSpeed * Time.deltaTime);

        // 获取鼠标水平移动输入
        float horizontalInput = Input.GetAxis("Mouse X");

        // 根据鼠标水平移动旋转摄像机（左右视角）
        transform.Rotate(Vector3.up, horizontalInput * lookSpeed);

        // 获取鼠标垂直移动输入
        float verticalMouseInput = Input.GetAxis("Mouse Y");

        // 根据鼠标垂直移动调整垂直旋转角度
        verticalRotation -= verticalMouseInput * lookSpeed;

        // 限制垂直旋转角度在指定范围内
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalLookLimit, verticalLookLimit);

        // 应用垂直旋转到主摄像机
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
}
