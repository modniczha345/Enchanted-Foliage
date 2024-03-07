using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed = 100.0f; // скорость поворота камеры
    public float minY = -60.0f; // минимальный угол поворота по оси Y
    public float maxY = 60.0f; // максимальный угол поворота по оси Y

    private float rotationY = 0.0f; // текущий угол поворота по оси Y

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X"); // получаем скорость мышки по оси X
        float mouseY = Input.GetAxis("Mouse Y"); // получаем скорость мышки по оси Y

        rotationY -= mouseY * rotationSpeed * Time.deltaTime; // изменяем угол поворота по оси Y
        rotationY = Mathf.Clamp(rotationY, minY, maxY); // ограничиваем угол поворота по оси Y в пределах minY и maxY

        transform.localEulerAngles = new Vector3(rotationY, transform.localEulerAngles.y + mouseX * rotationSpeed * Time.deltaTime, 0); // применяем поворот камеры
    }
}