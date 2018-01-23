using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core {

[CreateAssetMenu(fileName = "New Settings", menuName = "Settings")]
public class GameplaySettings : ScriptableObject {
	public int mazeLength;
	public int mazeWidth;
	public int cellSize;
	public MazeType mazeType; 
}

}