using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeaderData : MonoBehaviour
{
    
    public readonly string hand;
    public readonly string v1;
    public readonly string v2;
    public readonly string v3;
    public readonly string v4;
    public readonly string left;
    public readonly string right;
    
    public HeaderData(string hand, string v1, string v2, string v3, string v4, string left, string right){
        
        this.hand = hand;
        this.v1 = v1;
        this.v2 = v2;
        this.v3 = v3;
        this.v4 = v4;
        this.left = left;
        this.right = right;
        
    }
}
