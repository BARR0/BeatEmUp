using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symbol{
    private string token;

    public string Token { get { return token;}}

    public Symbol(string token){
        this.token = token;
    }
}
