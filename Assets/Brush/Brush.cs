using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Normal.Realtime;

public class Brush : RealtimeComponent<BrushModel> {
    // Reference to Realtime to use to instantiate brush strokes
    [SerializeField] private Realtime _realtime;

    // Prefab to instantiate when we draw a new brush stroke
    [SerializeField] private GameObject _brushStrokePrefab = null;

    private void Update() {
        if (!_realtime.connected)
            return;

        if (this.model.serverId == -1) {
            this.model.serverId = _realtime.clientID;
            Debug.Log("I am the server");
            return;
        }

        // if we are the host
        if (this.model.serverId == _realtime.clientID) {
            // update the model with the average
            if ((System.DateTime.Now.Ticks/10000) % 100 == 0) {
                Debug.Log(this.model.handModels.Count + " hands are in model");

                foreach (KeyValuePair<uint, HandModel> p in this.model.handModels) {
                    Debug.Log("     ClientID: " + p.Key);
                }
            }
        }



        // If the trigger is pressed and we haven't created a new brush stroke to draw, create one!
        // if (triggerPressed && _activeBrushStroke == null) {
        //     // Instantiate a copy of the Brush Stroke prefab.
        //     GameObject brushStrokeGameObject = Realtime.Instantiate(_brushStrokePrefab.name, ownedByClient: true, useInstance: _realtime);

        //     // Grab the BrushStroke component from it
        //     _activeBrushStroke = brushStrokeGameObject.GetComponent<BrushStroke>();

        //     // Tell the BrushStroke to begin drawing at the current brush position
        //     _activeBrushStroke.BeginBrushStrokeWithBrushTipPoint(_handPosition, _handRotation);
        // }

        // // If the trigger is pressed, and we have a brush stroke, move the brush stroke to the new brush tip position
        // if (triggerPressed)
        //     _activeBrushStroke.MoveBrushTipToPoint(_handPosition, _handRotation);

        // // If the trigger is no longer pressed, and we still have an active brush stroke, mark it as finished and clear it.
        // if (!triggerPressed && _activeBrushStroke != null) {
        //     _activeBrushStroke.EndBrushStrokeWithBrushTipPoint(_handPosition, _handRotation);
        //     _activeBrushStroke = null;
        // }
    }

    public void UpdateHand(int clientID, Vector3 _handPosition, Quaternion _handRotation, bool triggerPressed) {
        uint id = ((uint) clientID % 5000);
        // this.model.handModels.Remove((uint)clientID % 4000);
        HandModel modelRef;
        bool modelFound = this.model.handModels.TryGetValue(id, out modelRef);
        if (!modelFound) {
            HandModel model = new HandModel();
            model.position = _handPosition;
            model.rotation = _handRotation;
            model.triggerPressed = triggerPressed;
            
            this.model.handModels.Add(id, model);
        } else {
            modelRef.position = _handPosition;
            modelRef.rotation = _handRotation;
            modelRef.triggerPressed = triggerPressed;
        }
    }
}
