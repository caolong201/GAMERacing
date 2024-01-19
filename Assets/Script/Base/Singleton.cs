using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> where T : Singleton<T>, new()
{

    #region Fields

    /// <summary>
    /// The instance.
    /// </summary>
    private static T instance;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the instance.
    /// </summary>
    /// <value>The instance.</value>
    public static T Instance
    {
        get
        {
            if (Instance == null)
            {
                //ensure that only one thread can execute
                lock (typeof(T))
                {
                    if (Instance == null)
                    {
                        instance = new T();
                        instance.Init();
                    }
                }
            }

            return instance;
        }
    }


    #endregion

    #region Methods

    public static void CreateInstance()
    {
        DestroyInstance();
        instance = Instance;
    }

    public static void DestroyInstance()
    {
        if (instance == null) return;

        instance.Clear();
        instance = default(T);
    }

    protected void Init()
    {
        OnInit();
    }

    public void Clear()
    {
        OnClear();
    }

    protected virtual void OnInit()
    {
    }

    protected virtual void OnClear()
    {
    }
    #endregion

}

public abstract class MonoSingleton<T> : MonoBehaviour where T : Component
{

    #region Fields

    /// <summary>
    /// The instance.
    /// </summary>
    private static T instance;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the instance.
    /// </summary>
    /// <value>The instance.</value>
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    instance = obj.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Use this for initialization.
    /// </summary>
    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;

            if (Application.isPlaying)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            if (Application.isPlaying)
            {
                Destroy(gameObject);
            }
            else
            {
                DestroyImmediate(gameObject);
            }
        }
    }

    #endregion

}
