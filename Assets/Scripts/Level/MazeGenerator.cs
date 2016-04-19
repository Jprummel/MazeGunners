using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MazeGenerator : MonoBehaviour
{
	[System.Serializable]
	public class Cell
	{
		public bool visited;
		public GameObject north; //1
		public GameObject east;  //2
		public GameObject west;  //3
		public GameObject south; //4

	}

	[SerializeField]private List<GameObject> walls = new List<GameObject> ();
	[SerializeField]private List<GameObject> floors = new List<GameObject> ();
	[SerializeField]private float wallLength = 1.0f;
	[SerializeField]private int xSize = 5;
	[SerializeField]private int ySize = 5;

	private Vector3 initialPos;
	private GameObject wallHolder;
    private GameObject floorHolder;
	public Cell[] cells;

	private float floorOffset;
	private int currentCell;
	private int totalCells;
	private int visitedCells;
	private int currentNeighbour;
	private int backingUp;
	private int wallToBreak;
	private bool startedBuilding = false;

	private List<int> lastCells;

	// Use this for initialization
	void Start ()
	{
		floorOffset = floors [0].transform.localScale.y / 2;
		CreateWalls ();
	}

	void CreateWalls ()
	{
		wallHolder = new GameObject ();
		wallHolder.name = "maze";

		initialPos = new Vector3 ((-xSize / 2) + wallLength / 2, 0.0f, (-ySize / 2) + wallLength / 2);
		Vector3 myPos = initialPos;
		GameObject tempWall;
		//For x Axis
		for (int i = 0; i < ySize; i++) {
			for (int j = 0; j <= xSize; j++) {
				myPos = new Vector3 (initialPos.x + (j * wallLength) - wallLength / 2, 0.0f, initialPos.z + (i * wallLength) - wallLength / 2); //wall placement position
				tempWall = Instantiate (walls [0], myPos, Quaternion.identity) as GameObject;
				tempWall.transform.parent = wallHolder.transform;
			}
		}
		//For y Axis
		for (int i = 0; i <= ySize; i++) {
			for (int j = 0; j < xSize; j++) {
				myPos = new Vector3 (initialPos.x + (j * wallLength), 0.0f, initialPos.z + (i * wallLength) - wallLength); //wall placement position
				tempWall = Instantiate (walls [0], myPos, Quaternion.Euler (0, 90, 0)) as GameObject;
				tempWall.transform.parent = wallHolder.transform;
			}
		}
		CreateFloor ();
		CreateCells ();
	}

	void CreateFloor ()
	{
		Vector3 currentPosition = new Vector3 (0, -((wallLength / 2) + floorOffset), -wallLength / 2);
		GameObject floor = Instantiate (floors [0], currentPosition, Quaternion.identity) as GameObject;
		floor.transform.localScale = new Vector3 (xSize, floor.transform.localScale.y, ySize);
	}

	void CreateCells ()
	{
		lastCells = new List<int> ();
		lastCells.Clear ();
		GameObject[] allWalls;
		int children = wallHolder.transform.childCount;
		allWalls = new GameObject[children];
		cells = new Cell[xSize * ySize];
		totalCells = xSize * ySize;
		int eastWestProcess = 0;
		int childProcess = 0;
		int termCount = 0;

		//Gets all children
		for (int i = 0; i < children; i++) {
			allWalls [i] = wallHolder.transform.GetChild (i).gameObject;
		}

		//Assign walls to cells
		for (int i = 0; i < cells.Length; i++) {
			if (termCount == xSize) {
				eastWestProcess++;
				termCount = 0;
			}
			cells [i] = new Cell ();
			cells [i].east = allWalls [eastWestProcess];
			cells [i].south = allWalls [childProcess + (xSize + 1) * ySize];
			eastWestProcess++;

			termCount++;
			childProcess++;

			cells [i].west = allWalls [eastWestProcess];
			cells [i].north = allWalls [(childProcess + (xSize + 1) * ySize) + xSize - 1];

		}
		CreateMaze ();
	}

	void CreateMaze () //depth first search
	{
		while (visitedCells < totalCells) {
			if (startedBuilding) {
				GetNeighbour ();
				if (cells [currentNeighbour].visited == false && cells [currentCell].visited == true) {
					BreakWall ();
					VisitCell (currentNeighbour);
					lastCells.Add (currentCell);
					currentCell = currentNeighbour;
					if (lastCells.Count > 0) {
						backingUp = lastCells.Count - 1;
					}
				}

			} else {
				currentCell = Random.Range (0, totalCells);
				VisitCell (currentCell);
				startedBuilding = true;
			}
		}
	}

	void GetNeighbour () // checks neighbouring cells
	{
		int length = 0;
		int[] neighbours = new int[4]; // there are only a max of 4 neighbours for each cell,
		int[] connectingWall = new int[4];
		int check = 0;
		check = (currentCell + 1) / xSize;
		check -= 1;
		check *= xSize;
		check += xSize;

		//north
		if (currentCell + xSize < totalCells) {
			if (!cells [currentCell + xSize].visited) {
				neighbours [length] = currentCell + xSize;
				connectingWall [length] = 1;
				length++;
			}
		}

		//east
		if (currentCell - 1 >= 0 && currentCell != check) {
			if (!cells [currentCell - 1].visited) {
				neighbours [length] = currentCell - 1;
				connectingWall [length] = 2;
				length++;
			}
		}

		//west
		if (currentCell + 1 < totalCells && (currentCell + 1) != check) { //if current cell isn't exceding total cells & if next cell isn't a corner
			if (!cells [currentCell + 1].visited) {
				neighbours [length] = currentCell + 1;
				connectingWall [length] = 3;
				length++;
			}
		}

		//south
		if (currentCell - xSize >= 0) {
			if (!cells [currentCell - xSize].visited) {
				neighbours [length] = currentCell - xSize;
				connectingWall [length] = 4;
				length++;
			}
		}

		if (length != 0) {
			int randomNeighbour = Random.Range (0, length);
			currentNeighbour = neighbours [randomNeighbour];
			wallToBreak = connectingWall [randomNeighbour];
		} else {
			if (backingUp > 0) {
				currentCell = lastCells [backingUp];
				backingUp--;
			}
		}
	}

	void BreakWall ()
	{
		switch (wallToBreak) {
		case 1: Destroy (cells [currentCell].north); break;
		case 2: Destroy (cells [currentCell].east);  break;
		case 3: Destroy (cells [currentCell].west);  break;
		case 4: Destroy (cells [currentCell].south); break;
		}
	}

	void VisitCell (int visitedCell)
	{
		cells [visitedCell].visited = true;
		visitedCells++;
	}
}
