using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Chrono : MonoBehaviour
{
    static private Chrono cela;

    static public Chrono Instance
    {
        get
        {
            if (!cela) cela = FindObjectOfType<Chrono>();
            return cela;
        }
    }

    public UnityEvent chronoUpdate = new UnityEvent();

    [SerializeField] private float refreshRate = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MainRoutine(refreshRate));
    }

    private IEnumerator MainRoutine(float refresh)
    {
        while (true)
        {
            chronoUpdate.Invoke();
            yield return new WaitForSeconds(refresh);
        }
    }
}
