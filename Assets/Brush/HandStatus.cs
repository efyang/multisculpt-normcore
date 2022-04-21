using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class HandStatus : RealtimeComponent<HandModel>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.SetPositionAndRotation(this.model.position, this.model.rotation);
        var statusMarkerRenderer = this.GetComponent<Renderer>();
        if (this.model.triggerPressed) {
            statusMarkerRenderer.material.SetColor("_Color", new Color(0, 1, 0, 0.5f));
        } else {
            statusMarkerRenderer.material.SetColor("_Color", new Color(1, 0, 0, 0.5f));
        }
    }

    public void SyncHandData(Vector3 position, Quaternion rotation, bool triggerPressed, float weightingValue) {
        model.position = position;
        model.rotation = rotation;
        model.triggerPressed = triggerPressed;
        model.weightingValue = weightingValue;
    }

    private void Awake() {

    }
}
