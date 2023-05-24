using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousData : MonoBehaviour
{
    
    public readonly float time;
    public readonly int submitting;
    public readonly int checking;
    public readonly string v1;
    public readonly string v2;
    public readonly string v3;
    public readonly string v4;
    public readonly string left;
    public readonly string right;
    public readonly string draging;
    public readonly int v1correct;
    public readonly int v2correct;
    public readonly int v3correct;
    public readonly int v4correct;
    public readonly int leftcorrect;
    public readonly int rightcorrect;
    public Vector3 handPos;
    
    public ContinuousData(float time, int submitting, int checking, string v1, string v2, string v3, string v4, string left, string right, string draging, int v1correct, int v2correct, int v3correct, int v4correct, int leftcorrect, int rightcorrect, Vector3 handPos){
        
        this.time = time;
        this.submitting = submitting;
        this.checking = checking;
        this.v1 = v1;
        this.v2 = v2;
        this.v3 = v3;
        this.v4 = v4;
        this.left = left;
        this.right = right;
        this.draging = draging;
        this.v1correct = v1correct;
        this.v2correct = v2correct;
        this.v3correct = v3correct;
        this.v4correct = v4correct;
        this.leftcorrect = leftcorrect;
        this.rightcorrect = rightcorrect;
        this.handPos = handPos;
        
    }
    
}
