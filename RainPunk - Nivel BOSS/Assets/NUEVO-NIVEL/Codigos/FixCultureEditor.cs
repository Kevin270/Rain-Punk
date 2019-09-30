using System.Globalization;
using System.Threading;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
[InitializeOnLoad]

//Declaramos una clase estatica que se utiliza para evitar el bug de la animaciones hechas en 2d con unity 
public static class FixCultureEditor
{
    static FixCultureEditor()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
    }
}
#endif

public static class FixCultureRuntime
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void FixCulture()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
    }
}
