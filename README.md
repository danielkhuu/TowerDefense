# Tower Defense Game #?
 A "Balloon Tower Defense"-inspired Unity game
## About
Player must survive waves of robot enemies by placing towers to defend their base. 
#### Gameplay
* Enemy robots spawn in waves, with an enemy count indicator on the screen
* Player base has finite health
* Player can place 5 towers on certain spots of the map and are able to replace towers. 
   * Tower placement works using a FILO cycle (If all 5 towers are placed, then the first tower placed will be repositioned)
* 3D objects used are voxel assets imported from the Unity Asset store. I plan on creating my own 3D objects for this project in the future. 
* The enemy robots find the path to the player base using a breadth first search algorithm. 
   * As a result, the enemies only have one path to follow. Plans are made to change this to create a dynamic enemy
#### Project Status
Still in development! I work on this project during my free time. 

### Future Goals
* Different level designs
* Pause screen
* Multiple enemy paths
* Different types of enemies and defenses
* Pre-round screen (to allow player time to strategize and place towers)
   * Store menu for player to purchase extra defenses with points 
## Gallery
Work-in-Progress

## Usage
This is a Unity project, but you can build it for any platform Unity supports using the Unity game engine.
### Installation
* You will need to install 
   * Unity game engine 
   * A code editor (You will get the option to install Microsoft Visual Studio when installing Unity)
* After you have Unity installed, add the project to Unity (Unity will ask you to update the Unity version for the project, be sure you do)
### Build and Play
* You can build the project under the File tab. 
   * Be sure to change the build settings based on the operating system you use.
## File Structure
- The Assets folder is where the project's building blocks are located

| No | File Name | Details 
|----|------------|-------|
| 1  | Fonts | Text fonts
| 2  | Materials |  Paint jobs used for prefabs
| 3  | ParticleFX | Particle FX made using Unity
| 4  | Prefabs | Set of 3D objects made with Unity or imported from Unity Asset Store
| 5  | Scenes | Consists of loading and instruction screen, and main game level
| 6  | Scripts | C# scripts 
| 7  | SkyBox Volume 2 | Skybox assets imported from Unity Asset Store
| 8  | SoundFX | Enemy and tower sound effects, explosion sounds
| 9  | TextMesh Pro | Unity package for text
| 10 | Voxel Assets | 3D cubes made from Voxel, imported through Unity Asset Store

## License
![License](https://github.com/danielkhuu/ProjectRocket/blob/master/LICENSE.txt)
