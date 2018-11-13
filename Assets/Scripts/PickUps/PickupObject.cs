using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject{

    private string name;
    private string type;

    public PickupObject(string name, string type) {
        this.name = name;
        this.type = type;
    }

    public string GetName() {
        return this.name;
    }

    public string GetType() {
        return this.type;
    }
}
