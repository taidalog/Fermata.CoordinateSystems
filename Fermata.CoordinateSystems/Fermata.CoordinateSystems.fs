namespace Fermata

module CoordinateSystems =
    type Rectangle =
        { Width : float
          Height : float }
    
    type Point =
        { X : float
          Y : float }
    
    type Origin = Point

    type Screen =
        { Rectangle : Rectangle
          Origin : Origin
          Point : Point }
    
    type Cartesian =
        { Rectangle : Rectangle
          Origin : Origin
          Point : Point }
    

    let createCartesian (rectangle: Rectangle) (origin: Origin) (x: float) (y: float) : Cartesian =
        {
            Cartesian.Rectangle = rectangle
            Cartesian.Origin = origin
            Cartesian.Point =
                { Point.X = x; Y = y }
        }
    

    [<RequireQualifiedAccess>]
    module Screen =
        let create (rectangle: Rectangle) (origin: Origin) (x: float) (y: float) : Screen =
            {
                Screen.Rectangle = rectangle
                Screen.Origin = origin
                Screen.Point =
                    { Point.X = x; Y = y }
            }
        
        let toCartesian (origin: Origin) (screen: Screen) : Cartesian =
            let x' = screen.Point.X + (screen.Origin.X - origin.X)
            let y' = -screen.Point.Y - (screen.Origin.Y - origin.Y)
            createCartesian screen.Rectangle origin x' y'
        
        let ofCartesian (origin: Origin) (cartesian: Cartesian) : Screen =
            let x' = cartesian.Point.X + (cartesian.Origin.X - origin.X)
            let y' = -cartesian.Point.Y + (cartesian.Origin.Y - origin.Y)
            create cartesian.Rectangle origin x' y'
    

    [<RequireQualifiedAccess>]
    module Cartesian =
        let create (rectangle: Rectangle) (origin: Origin) (x: float) (y: float) : Cartesian = 
            createCartesian rectangle origin x y
        
        let toScreen (origin: Origin) (cartesian: Cartesian) : Screen =
            Screen.ofCartesian origin cartesian
        
        let ofScreen (origin: Origin) (screen: Screen) : Cartesian =
            Screen.toCartesian origin screen
