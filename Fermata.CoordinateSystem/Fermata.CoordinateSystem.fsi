namespace Fermata
    
    module CoordinateSystem =
        
        type Rectangle =
            {
              Width: float
              Height: float
            }
        
        type Coordinate =
            {
              X: float
              Y: float
            }
        
        type Origin = Coordinate
        
        type Screen =
            {
              Rectangle: Rectangle
              Origin: Origin
              Coordinate: Coordinate
            }
        
        type Cartesian =
            {
              Rectangle: Rectangle
              Origin: Origin
              Coordinate: Coordinate
            }
        
        val createCartesian:
          rectangle: Rectangle ->
            origin: Origin -> x: float -> y: float -> Cartesian
        
        [<RequireQualifiedAccess>]
        module Screen =
            
            val create:
              rectangle: Rectangle ->
                origin: Origin -> x: float -> y: float -> Screen
            
            val toCartesian: origin: Origin -> screen: Screen -> Cartesian
            
            val ofCartesian: origin: Origin -> cartesian: Cartesian -> Screen
        
        [<RequireQualifiedAccess>]
        module Cartesian =
            
            val create: (Rectangle -> Origin -> float -> float -> Cartesian)
            
            val toScreen: (Origin -> Cartesian -> Screen)
            
            val ofScreen: (Origin -> Screen -> Cartesian)

