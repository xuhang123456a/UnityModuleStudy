using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PersistableObject : MonoBehaviour
{
    public virtual void Save(GameDataWrite write)
    {
        write.Write(transform.localPosition);
        write.Write(transform.localRotation);
        write.Write(transform.localScale);
    }

    public virtual void Load(GameDataReader reader)
    {
        transform.localPosition = reader.ReadVector3();
        transform.localRotation = reader.ReadQuaternion();
        transform.localScale = reader.ReadVector3();
    }
}
