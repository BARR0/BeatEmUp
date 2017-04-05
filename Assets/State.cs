using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class State {

	private string name;

	// Monobehaiviors
	// List of behavoiors
	private Type behavior;

	// transitions
	private Dictionary<Symbol, State> transitions;

	public string Name {
		get { return name; }
	}

	public Dictionary<Symbol, State> Transitions {
		get { return transitions; }
	}

	public Type Behavior {
		get { return behavior; }
	}

	public State(string name, Type behavior) {
		this.name = name;
		this.behavior = behavior;
		transitions = new Dictionary<Symbol, State> ();
	}

	public void AddNeighbor( Symbol key, State neighbor) {

		transitions.Add (key, neighbor);
	}

	public State ApplySymbol(Symbol symbol) {

		if (!transitions.ContainsKey(symbol)) 
			return this;

		return transitions[symbol];
	}
}