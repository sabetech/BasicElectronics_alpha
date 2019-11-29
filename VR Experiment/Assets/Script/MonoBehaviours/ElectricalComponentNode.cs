using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalComponentNode 
{
    ElectricalComponentNode currentConnectionComponent;
    List<ElectricalComponentNode> nextConnectionComponent;
    List<ElectricalComponentNode> previousConnectionComponent;

    public bool hasNextComponent()
    {
        return false;
    }

    public bool hasAnotherNext(int nextNodeIndex)
    {
        return false;
    }





    

}
