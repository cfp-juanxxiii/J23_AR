using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoControllerScript : MonoBehaviour {
    public VideoPlayer vp;
    public GameObject firstFrame;
    private bool firstTime=true;

    private void Start()
    {
        vp.frame = 1;
    }

    void Update () {
        if (Input.touches.Length > 0 && Input.touches[0].phase==TouchPhase.Began)
        {
            GameObject go = GetTouchedGO();
            ProcesarGO(go);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            GameObject go = GetClickedGO();
            ProcesarGO(go);
        }
    }

    private void ProcesarGO(GameObject go)
    {
        if (go.name == "VideoController")
        {
            if (!vp.isPlaying)
            {
                if (firstTime)
                {
                    firstTime = false;
                    Destroy(firstFrame);
                }
                vp.Play();
            }
            else
            {
                vp.Pause();
            }
        }
    }

    private GameObject GetTouchedGO()
    {
        GameObject touchedGO = null;
        Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        RaycastHit raycastHit;
        if (Physics.Raycast(raycast, out raycastHit))
        {
            touchedGO = raycastHit.transform.gameObject;
        }
        return touchedGO;
    }

    private GameObject GetClickedGO()
    {
        GameObject touchedGO = null;
        Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;
        if (Physics.Raycast(raycast, out raycastHit))
        {
            touchedGO = raycastHit.transform.gameObject;
        }
        return touchedGO;
    }
}
