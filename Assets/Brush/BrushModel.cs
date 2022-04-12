using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using Normal.Realtime.Serialization;

[RealtimeModel]
public partial class BrushModel {
    [RealtimeProperty(1, true)]
    private int _serverId = -1;

    [RealtimeProperty(2, true)]
    private Vector3    _position;

    [RealtimeProperty(3, true)]
    private Quaternion _rotation = Quaternion.identity;

    // active brushstroke
    [RealtimeProperty(4, true)]
    private BrushStrokeModel _activeBrushstroke = null;
}

/* ----- Begin Normal Autogenerated Code ----- */
public partial class BrushModel : RealtimeModel {
    public int serverId {
        get {
            return _serverIdProperty.value;
        }
        set {
            if (_serverIdProperty.value == value) return;
            _serverIdProperty.value = value;
            InvalidateReliableLength();
        }
    }
    
    public UnityEngine.Vector3 position {
        get {
            return _positionProperty.value;
        }
        set {
            if (_positionProperty.value == value) return;
            _positionProperty.value = value;
            InvalidateReliableLength();
        }
    }
    
    public UnityEngine.Quaternion rotation {
        get {
            return _rotationProperty.value;
        }
        set {
            if (_rotationProperty.value == value) return;
            _rotationProperty.value = value;
            InvalidateReliableLength();
        }
    }
    
    public BrushStrokeModel activeBrushstroke {
        get => _activeBrushstroke;
    }
    
    public enum PropertyID : uint {
        ServerId = 1,
        Position = 2,
        Rotation = 3,
        ActiveBrushstroke = 4,
    }
    
    #region Properties
    
    private ReliableProperty<int> _serverIdProperty;
    
    private ReliableProperty<UnityEngine.Vector3> _positionProperty;
    
    private ReliableProperty<UnityEngine.Quaternion> _rotationProperty;
    
    private ModelProperty<BrushStrokeModel> _activeBrushstrokeProperty;
    
    #endregion
    
    public BrushModel() : base(null) {
        RealtimeModel[] childModels = new RealtimeModel[1];
        
        _activeBrushstroke = new BrushStrokeModel();
        childModels[0] = _activeBrushstroke;
        
        SetChildren(childModels);
        
        _serverIdProperty = new ReliableProperty<int>(1, _serverId);
        _positionProperty = new ReliableProperty<UnityEngine.Vector3>(2, _position);
        _rotationProperty = new ReliableProperty<UnityEngine.Quaternion>(3, _rotation);
        _activeBrushstrokeProperty = new ModelProperty<BrushStrokeModel>(4, _activeBrushstroke);
    }
    
    protected override void OnParentReplaced(RealtimeModel previousParent, RealtimeModel currentParent) {
        _serverIdProperty.UnsubscribeCallback();
        _positionProperty.UnsubscribeCallback();
        _rotationProperty.UnsubscribeCallback();
    }
    
    protected override int WriteLength(StreamContext context) {
        var length = 0;
        length += _serverIdProperty.WriteLength(context);
        length += _positionProperty.WriteLength(context);
        length += _rotationProperty.WriteLength(context);
        length += _activeBrushstrokeProperty.WriteLength(context);
        return length;
    }
    
    protected override void Write(WriteStream stream, StreamContext context) {
        var writes = false;
        writes |= _serverIdProperty.Write(stream, context);
        writes |= _positionProperty.Write(stream, context);
        writes |= _rotationProperty.Write(stream, context);
        writes |= _activeBrushstrokeProperty.Write(stream, context);
        if (writes) InvalidateContextLength(context);
    }
    
    protected override void Read(ReadStream stream, StreamContext context) {
        var anyPropertiesChanged = false;
        while (stream.ReadNextPropertyID(out uint propertyID)) {
            var changed = false;
            switch (propertyID) {
                case (uint) PropertyID.ServerId: {
                    changed = _serverIdProperty.Read(stream, context);
                    break;
                }
                case (uint) PropertyID.Position: {
                    changed = _positionProperty.Read(stream, context);
                    break;
                }
                case (uint) PropertyID.Rotation: {
                    changed = _rotationProperty.Read(stream, context);
                    break;
                }
                case (uint) PropertyID.ActiveBrushstroke: {
                    changed = _activeBrushstrokeProperty.Read(stream, context);
                    break;
                }
                default: {
                    stream.SkipProperty();
                    break;
                }
            }
            anyPropertiesChanged |= changed;
        }
        if (anyPropertiesChanged) {
            UpdateBackingFields();
        }
    }
    
    private void UpdateBackingFields() {
        _serverId = serverId;
        _position = position;
        _rotation = rotation;
        _activeBrushstroke = activeBrushstroke;
    }
    
}
/* ----- End Normal Autogenerated Code ----- */
