# 2D-Rotation-map-in-unity

## Preview
  This section provide an overview of the **Rotation.cs** Code.
  The **Rotation.cs** class is a very modular class that you can use in your project to Rotate 2D objects with given direction and speed for a specific time and keep changing those values as you pleases, this code help you make levels where you need to rotate things like this without going in depth of how to do it.
  
  ![](https://github.com/AhmadShannak/2D-Rotation-map-in-unity/blob/master/Rotation%20Repo/UnityGif.gif)
  
## How to use it 
  All you need to use this project is to download the **Rotation.cs** file, then attach it to the gameObject that you want to control its roation.
  
  The **Rotation.cs** script has 3 functions that can be accessed by any other script:
  #### Code Interface :
    - SetSizeForAllArrays(int size) -> This function is used to set the number of how many roations change will be on the level.
    
    - SetRotationDetails(int index, float rotationSpeed,float rotationTime,char rotationDirection) -> Those function will be called for     each time that the rotation will change on that level, in simple terms "For the first rotation make the speed of that roation = x and     keep it rotating for t seconds, and let the direction of that rotation be 'r' which means to the right".
    
    - RotationManager() -> This function(IEnumerator) is called to excute the rotation after you have set the above functions for the level.
    
    
    
  Finally in your level script you should have something like this:
  
  ![howToUseIt](https://github.com/AhmadShannak/2D-Rotation-map-in-unity/blob/master/Rotation%20Repo/HowToUse.png)
