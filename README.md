# Bridge-Jumpers
Bienvenidos a Bridge jumpers un juego donde la coordinación y la precisión son cruciales ,
Un juego de plataformas donde el objetivo es superarse constantemente , pero cuidado que detrás tuyo siempre existe un peligro inminente.
Te atreves a tomar el reto. 
Descubre el reino de Torment y a sus habitantes los cuales podrás desbloquear y jugar con ellos.
Corre , Salta y sobre todo Supérate a ti mismo.

Desing Patterns
Los patrones utilizados son:
Object pulling y Factory en la clase de BridgeManager para spawnear los distintos tipos de puentes y cuando los pinches chocan con un puente lo devuelven a la pool de objetos para poder ser re utilizados.
Memento que fue utilizado tanto para la plata del jugador como el guardado de los personajes y algunas variables mas para que se pueda guardar su estado entre partidas y de esta manera poder guardar el progreso del jugador.
Este patron fue utilizado entre otros lugares en el Game Manager del gameplay para poder guardar el high score del player.
