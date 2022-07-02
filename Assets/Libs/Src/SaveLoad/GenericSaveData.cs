using System;

[Serializable]
public abstract class GenericSaveData<T> : IGenericSaveData
{
    public string GetAssemblyName()
    {
        return typeof(T).AssemblyQualifiedName;
    }

    public Type GetSaveType()
    {
        return Type.GetType(GetAssemblyName());
    }
}