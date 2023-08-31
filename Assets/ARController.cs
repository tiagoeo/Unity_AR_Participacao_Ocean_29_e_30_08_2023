using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARController : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        Vector2 screenCenter = new Vector2(Screen.width/2, Screen.height/2);

        raycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        if (hits.Count > 0 && !target.activeSelf)
        {
            target.transform.position = hits[0].pose.position;
            target.SetActive(true);
        }
    }
}
