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

    Color GREEN = new Color(0, 1, 0, 0.5f);
    Color RED = new Color(1, 0, 0, 0.5f);

    // Update is called once per frame
    void Update()
    {
        this.transform.SetPositionAndRotation(this.model.position, this.model.rotation);
        var weightMarkerObject = this.transform.GetChild(1).gameObject;
        var triggerMarkerObject = this.transform.GetChild(0).gameObject;
        var triggerMarkerRenderer = triggerMarkerObject.GetComponent<Renderer>();
        var weightMarkerRenderer = weightMarkerObject.GetComponent<Renderer>();
        if (this.model.triggerPressed) {
            triggerMarkerRenderer.material.SetColor("_Color", GREEN);
        } else {
            triggerMarkerRenderer.material.SetColor("_Color", RED);
        }
        weightMarkerRenderer.material.SetColor("_Color", GREEN * this.model.weightingValue + RED * (1 - this.model.weightingValue));
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
