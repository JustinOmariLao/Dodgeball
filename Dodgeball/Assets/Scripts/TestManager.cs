using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public Camera mainCam;
    public Camera sideCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwapCameras() {
        mainCam.enabled = !mainCam.enabled;
        sideCam.enabled = !sideCam.enabled;
    }
}
