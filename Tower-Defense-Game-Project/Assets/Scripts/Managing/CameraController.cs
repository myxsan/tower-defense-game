using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    private float zoomSpeed = 10f;
    public Vector2 zoomClamp = new Vector2(10f, 80f);
    public Vector2 horizontalClamp = new Vector2(10f, 80f);
    public Vector2 verticalClamp = new Vector2(10f, 80f);

    void Update()
    {
        if(GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        SetMoveInput();
        ZoomInAndOut();
    }

    private void ZoomInAndOut()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * zoomSpeed * Time.deltaTime;

        pos.y = Mathf.Clamp(pos.y, zoomClamp.x, zoomClamp.y);
        pos.x = Mathf.Clamp(pos.x, horizontalClamp.x, horizontalClamp.y);
        pos.z = Mathf.Clamp(pos.z, verticalClamp.x, verticalClamp.y);

        transform.position = pos; 
    }

    private void SetMoveInput()
    {
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
    }
}
