using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class clearFlag : MonoBehaviour
{
    public CameraClearFlags customClearFlags = CameraClearFlags.Skybox; // Set your custom clear flags here

    void Start()
    {
        // Get the camera component
        Camera camera = GetComponent<Camera>();
        if (camera != null)
        {
            // Set the clear flags
            camera.clearFlags = customClearFlags;
        }
        else
        {
            Debug.LogWarning("Camera component not found on the camera GameObject.");
        }
    }

}
