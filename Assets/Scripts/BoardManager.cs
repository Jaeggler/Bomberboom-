using UnityEngine;
using System.Collections.Generic;


public class BoardManager : MonoBehaviour {

	public int columns; //Variable del número de columnas total que tendra el tablero (Incluye los limites fisicos del juego).
	public int rows; //Variable del número de filas total que tendra el tablero (Incluye los limites fisicos del juego).

	public GameObject FloorTile;
	public GameObject SolidWall;
	public GameObject DestWallTile;


	//private List <Vector3> ItemsPos = new List <Vector3> ();
	private List <Vector3> ForbiddenPos = new List <Vector3> ();
	private Transform boardholder;
	private Transform destructibles;


	// Use this for initialization
	void Awake() {
		ForbiddenPos.Add (new Vector3 (1, 1, 0.0f));
		ForbiddenPos.Add (new Vector3 (1, 2, 0.0f));
		ForbiddenPos.Add (new Vector3 (2, 1, 0.0f));
		ForbiddenPos.Add (new Vector3 (1, (rows - 2), 0.0f));
		ForbiddenPos.Add (new Vector3 (1, (rows - 3), 0.0f));
		ForbiddenPos.Add (new Vector3 (2, (rows - 2), 0.0f));
		ForbiddenPos.Add (new Vector3 ((columns - 3), 1, 0.0f));
		ForbiddenPos.Add (new Vector3 ((columns - 2), 1, 0.0f));
		ForbiddenPos.Add (new Vector3 ((columns - 2), 2, 0.0f));
		ForbiddenPos.Add (new Vector3 ((columns - 3), (rows - 2), 0.0f));
		ForbiddenPos.Add (new Vector3 ((columns - 2), (rows - 2), 0.0f));
		ForbiddenPos.Add (new Vector3 ((columns - 2), (rows - 3), 0.0f));
		BoardConstructor ();
		InteractiveLocator (DestWallTile, 140, 140);
	
	}
	//Algoritmo de construccion del tablero.
	void BoardConstructor(){

		//Se crea un nuevo GameObject y se asigna su "transform" a la variable boardholder
		boardholder = new GameObject ("Board").transform;

		//Loop para definir las coordenadas de cada "tile" del tablero
		for(int i=0; i < columns; i++){
			for (int j = 0; j < rows; j++) {

				//Se define una variable que alojara el GameObject del piso.
				GameObject toInstantiate = FloorTile;

				//Una condicional que definirá que si "i" o "j" tienen valor 0 o el de la columna-1 entonces redefine la variable "toInstantiate"
				if (i == 0 || i == (columns - 1) || j == 0 || j == (columns - 1) || ( i % 2 == 0 && j %2 == 0)) {
					toInstantiate = SolidWall;
					ForbiddenPos.Add (new Vector3 (i, j, 0.0f));
				}

				//Se almacena la instancia generada en una variable llamada "instance" y como dato GameObject para luego usar su transform y emparentarlo con
				// la variable boardholder(del tipo transform).
				GameObject instance = Instantiate (toInstantiate, new Vector3 (i, j, 0.0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (boardholder);
			}
		}
	}

	List <Vector3> GridMapping(){

		List <Vector3> GridMap = new List <Vector3> ();

		//Se limpia la lista de niveles previos.
		GridMap.Clear ();

		//Se crea el loop que añadira las posiciones a la lista.
		for (int i = 1; i < columns - 1; i++){
			for(int j = 1; j < rows - 1; j++){
				GridMap.Add (new Vector3 (i, j, 0.0f));
			}
		}
		return GridMap;
	}

	Vector3 RandomPos (List <Vector3> RanPos){

		//Se crea el valor al azar.
		int RandomIndex = Random.Range(1,RanPos.Count);

		//Se asigna una posicion (vector 3) usando el valor anterior.
		Vector3 RandomPos = RanPos [RandomIndex];

		//Se retira de la lista para que ya no se pueda usar la misma posición
		RanPos.RemoveAt (RandomIndex);

		//Regresa la posicion al azar
		return RandomPos;
	}

	void InteractiveLocator(GameObject Interactive, int min, int max){
		int ObjectCount = Random.Range (min, max);
		List <Vector3> PosiblePos = GridMapping ();
		for (int x = 1; x <= ObjectCount; x++) {
			Vector3 RandomPosition = RandomPos (PosiblePos);
			if(!ForbiddenPos.Contains(RandomPosition)){
				Instantiate (Interactive, RandomPosition, Quaternion.identity);
			}
		}
	}

}
