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
	[SerializeField]private List<GameObject> _floors = new List<GameObject> ();
	[SerializeField]private GameObject ceiling;
	[SerializeField]private float _wallLength = 1.0f;
	[SerializeField]private float _floorYOffset = .7f;
	[SerializeField]private int _xSize = 10;
	[SerializeField]private int _ySize = 10;
	[SerializeField]private GameObject[] _players = new GameObject[4];

	private int[] _playerSpawnCellNumbers = new int[4];

	private Vector3 _initialPos;
	private GameObject _wallHolder;
    private GameObject _floorHolder;
	private Cell[] _cells;

	private int _currentCell;
	private int _totalCells;
	private int _visitedCells;
	private int _currentNeighbour;
	private int _backingUp;
	private int _wallToBreak;
	private bool _startedBuilding = false;

	private List<int> _lastCells;

	//Importing settings from datahandler here!!!
	private LevelData _levelData;
	//[SerializeField]private GameObject[] _placeholderPlayers = new GameObject[4];

	// Use this for initialization
	void Start ()
	{
		_levelData = GameObject.FindGameObjectWithTag ("LevelData").GetComponent<LevelData> ();
		Preperation();
		CreateWalls ();

	}
	public void ReGenerate(){
		Destroy (_wallHolder);
		Destroy (_floorHolder);
		FindAndPoolPlayers ();
		_cells = null;
		_currentCell = 0;
		_totalCells = 0;
		_visitedCells = 0;
		_currentNeighbour = 0;
		_backingUp = 0;
		_wallToBreak = 0;
		_startedBuilding = false;
		Preperation ();
		CreateWalls ();
	}

	void CreateWalls ()
	{
		_wallHolder = new GameObject ();
		_wallHolder.name = "maze";
		_floorHolder = new GameObject ();
		_wallHolder.name = "floor";

		_initialPos = new Vector3 ((-_xSize / 2) + _wallLength / 2, 0.0f, (-_ySize / 2) + _wallLength / 2);
		Vector3 myPos = _initialPos;
		GameObject tempWall;
	    GameObject tempFloor;
		//For x Axis
		for (int i = 0; i < _ySize; i++) {
			for (int j = 0; j <= _xSize; j++) {
				myPos = new Vector3 (_initialPos.x + (j * _wallLength) - _wallLength / 2, 0.0f, _initialPos.z + (i * _wallLength) - _wallLength / 2); //wall placement position
				tempWall = Instantiate (walls [0], myPos, Quaternion.identity) as GameObject;
				tempWall.transform.parent = _wallHolder.transform;
				myPos.x += _wallLength / 2;
				myPos.y = -_floorYOffset;
				tempFloor = Instantiate (_floors [0], myPos, Quaternion.identity) as GameObject;
				tempFloor.transform.parent = _floorHolder.transform;
				myPos.y = _floorYOffset;
				tempFloor = Instantiate (ceiling, myPos, Quaternion.identity) as GameObject;
				tempFloor.transform.parent = _floorHolder.transform;

			}
		}
		//For y Axis
		for (int i = 0; i <= _ySize; i++) {
			for (int j = 0; j < _xSize; j++) {
				myPos = new Vector3 (_initialPos.x + (j * _wallLength), 0.0f, _initialPos.z + (i * _wallLength) - _wallLength); //wall placement position
				tempWall = Instantiate (walls [0], myPos, Quaternion.Euler (0, 90, 0)) as GameObject;
				tempWall.transform.parent = _wallHolder.transform;
			}
		}
		CreateCells ();
	}

	void CreateFloor ()
	{
		Vector3 currentPosition = new Vector3(0, -_floorYOffset, -_wallLength / 2);
		GameObject floor = Instantiate (_floors [0], currentPosition, Quaternion.identity) as GameObject;
	}

	void CreateCells ()
	{
		_lastCells = new List<int> ();
		_lastCells.Clear ();
		GameObject[] allWalls;
		int children = _wallHolder.transform.childCount;
		allWalls = new GameObject[children];
		_cells = new Cell[_xSize * _ySize];
		_totalCells = _xSize * _ySize;
		int eastWestProcess = 0;
		int childProcess = 0;
		int termCount = 0;

		//Gets all children
		for (int i = 0; i < children; i++) {
			allWalls [i] = _wallHolder.transform.GetChild (i).gameObject;
		}

		//Assign walls to cells
		for (int i = 0; i < _cells.Length; i++) {
			if (termCount == _xSize) {
				eastWestProcess++;
				termCount = 0;
			}
			_cells [i] = new Cell ();
			_cells [i].east = allWalls [eastWestProcess];
			_cells [i].south = allWalls [childProcess + (_xSize + 1) * _ySize];
			eastWestProcess++;

			termCount++;
			childProcess++;

			_cells [i].west = allWalls [eastWestProcess];
			_cells [i].north = allWalls [(childProcess + (_xSize + 1) * _ySize) + _xSize - 1];

		}
		CreateMaze ();
	}

	void CreateMaze () //depth first search
	{
		while (_visitedCells < _totalCells) {
			if (_startedBuilding) {
				GetNeighbour ();
				if (_cells [_currentNeighbour].visited == false && _cells [_currentCell].visited == true) {
					BreakWall ();
					VisitCell (_currentNeighbour);
					_lastCells.Add (_currentCell);
					_currentCell = _currentNeighbour;
					if (_lastCells.Count > 0) {
						_backingUp = _lastCells.Count - 1;
					}
				}

			} else {
				_currentCell = Random.Range (0, _totalCells);
				VisitCell (_currentCell);
				_startedBuilding = true;
			}
		}
		placeAndSetPlayers ();
	}

	void GetNeighbour () // checks neighbouring cells
	{
		int length = 0;
		int[] neighbours = new int[4]; // there are only a max of 4 neighbours for each cell,
		int[] connectingWall = new int[4];
		int check = 0;
		check = (_currentCell + 1) / _xSize;
		check -= 1;
		check *= _xSize;
		check += _xSize;

		//north
		if (_currentCell + _xSize < _totalCells) {
			if (!_cells [_currentCell + _xSize].visited) {
				neighbours [length] = _currentCell + _xSize;
				connectingWall [length] = 1;
				length++;
			}
		}

		//east
		if (_currentCell - 1 >= 0 && _currentCell != check) {
			if (!_cells [_currentCell - 1].visited) {
				neighbours [length] = _currentCell - 1;
				connectingWall [length] = 2;
				length++;
			}
		}

		//west
		if (_currentCell + 1 < _totalCells && (_currentCell + 1) != check) { //if current cell isn't exceding total cells & if next cell isn't a corner
			if (!_cells [_currentCell + 1].visited) {
				neighbours [length] = _currentCell + 1;
				connectingWall [length] = 3;
				length++;
			}
		}

		//south
		if (_currentCell - _xSize >= 0) {
			if (!_cells [_currentCell - _xSize].visited) {
				neighbours [length] = _currentCell - _xSize;
				connectingWall [length] = 4;
				length++;
			}
		}

		if (length != 0) {
			int randomNeighbour = Random.Range (0, length);
			_currentNeighbour = neighbours [randomNeighbour];
			_wallToBreak = connectingWall [randomNeighbour];
		} else {
			if (_backingUp > 0) {
				_currentCell = _lastCells [_backingUp];
				_backingUp--;
			}
		}
	}

	void BreakWall ()
	{
		switch (_wallToBreak) {
		case 1: Destroy (_cells [_currentCell].north); break;
		case 2: Destroy (_cells [_currentCell].east);  break;
		case 3: Destroy (_cells [_currentCell].west);  break;
		case 4: Destroy (_cells [_currentCell].south); break;
		}
	}

	void VisitCell (int visitedCell)
	{
		_cells [visitedCell].visited = true;
		_visitedCells++;
	}

	public void ClearMaze(){
		CreateWalls ();
	}

	void Preperation(){
		_xSize = _levelData.mapLength;
		_ySize = _levelData.mapWidth;
		_playerSpawnCellNumbers [0] = 0;
		if (_levelData.GetPlayers == 2) { //2players
			_playerSpawnCellNumbers [1] = _ySize * _xSize - 1; //WWWWWWWWW
		} else {//4players
			_playerSpawnCellNumbers [1] = _ySize -1;
			_playerSpawnCellNumbers [2] = ((_ySize * _xSize) - _ySize);
			_playerSpawnCellNumbers [3] = _ySize * _xSize - 1;
		}
	}

	void placeAndSetPlayers(){
		GameObject tempPlayer;
		if (_levelData.GetPlayers == 2) {
			tempPlayer = ObjectPool.instance.GetObjectForType (ObjectPoolNames.PLAYER1,true);
			Vector3 spawnLocation = new Vector3(_cells[_playerSpawnCellNumbers[0]].west.transform.position.x - .5f,-0.45f,_cells[_playerSpawnCellNumbers[0]].west.transform.position.z);
			tempPlayer.transform.position = spawnLocation;

			tempPlayer = ObjectPool.instance.GetObjectForType (ObjectPoolNames.PLAYER2,true);
			spawnLocation = new Vector3(_cells[_playerSpawnCellNumbers[1]].east.transform.position.x + .5f,-0.45f,_cells[_playerSpawnCellNumbers[1]].east.transform.position.z);
			tempPlayer.transform.position = spawnLocation;
			Debug.Log("ech");
		}else {
			tempPlayer = ObjectPool.instance.GetObjectForType (ObjectPoolNames.PLAYER1,true);
			Vector3 spawnLocation = new Vector3(_cells[_playerSpawnCellNumbers[0]].west.transform.position.x - .5f,-0.45f,_cells[_playerSpawnCellNumbers[0]].west.transform.position.z);
			if (tempPlayer != null) {
				tempPlayer.transform.position = spawnLocation;
			}
			tempPlayer = ObjectPool.instance.GetObjectForType (ObjectPoolNames.PLAYER2,true);
			spawnLocation = new Vector3(_cells[_playerSpawnCellNumbers[1]].east.transform.position.x + .5f,-0.45f,_cells[_playerSpawnCellNumbers[1]].east.transform.position.z);
			if (tempPlayer != null) {
				tempPlayer.transform.position = spawnLocation;
			}
			tempPlayer = ObjectPool.instance.GetObjectForType (ObjectPoolNames.PLAYER3,true);
			spawnLocation = new Vector3(_cells[_playerSpawnCellNumbers[2]].west.transform.position.x - .5f,-0.45f,_cells[_playerSpawnCellNumbers[2]].west.transform.position.z);
			if (tempPlayer != null) {
				tempPlayer.transform.position = spawnLocation;
			}
			tempPlayer = ObjectPool.instance.GetObjectForType (ObjectPoolNames.PLAYER4,true);
			spawnLocation = new Vector3(_cells[_playerSpawnCellNumbers[3]].east.transform.position.x + .5f,-0.45f,_cells[_playerSpawnCellNumbers[3]].east.transform.position.z);
			if (tempPlayer != null) {
				tempPlayer.transform.position = spawnLocation;
			}
		}

	}

	void FindAndPoolPlayers(){
		_players [0] = GameObject.FindGameObjectWithTag (ObjectPoolNames.PLAYER1);
		_players [1] = GameObject.FindGameObjectWithTag (ObjectPoolNames.PLAYER2);
		_players [2] = GameObject.FindGameObjectWithTag (ObjectPoolNames.PLAYER3);
		_players [3] = GameObject.FindGameObjectWithTag (ObjectPoolNames.PLAYER4);

		for (int i = 0; i < _players.Length; i++) {
			if (_players [i] != null) {
				_players [i].GetComponent<PlayerDeath> ().FastKill ();
			}
		}
	}
}
