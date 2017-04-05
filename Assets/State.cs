using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class State{
    private string name;

    //Monobehaviours
    //list of behaviours
    private System.Type behaviour;

    //transition
    private Dictionary<Symbol, State> transitions;

    public string Name{
        get { return name; }
    }

    public Dictionary<Symbol, State> Transitions{
        get { return transitions; }
    }

    public Type Behaviour
    {
        get { return behaviour; }
    }

    public State (string name, Type behaviour)
    {
        this.name = name;
        this.behaviour = behaviour;
        this.transitions = new Dictionary<Symbol, State>();
    }

    public State(string name){
        this.name = name;
    }

    public void AddTransition(Symbol key, State state){
        transitions.Add(key, state);
    }

    public State ApplySymbol(Symbol symbol){
        if (transitions.ContainsKey(symbol))
            return this;
        return transitions[symbol];
    }
}
