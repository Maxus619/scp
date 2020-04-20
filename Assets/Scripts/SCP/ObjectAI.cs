using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAI : MonoBehaviour
{
    public enum DangerClass { Safe, Euclid, Keter }
    // public DangerClass danger;
    public string danger;
    
    string[] safeTraits = { "heal", "stealItem" };
    string[] euclidTraits = { "" };
    string[] keterTraits = { "" };
}