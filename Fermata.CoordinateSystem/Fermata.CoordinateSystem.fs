namespace Fermata

module CoordinateSystem =
    type Rectangle =
        { Width : float
          Height : float }
    
    type Coordinate =
        { X : float
          Y : float }
    
    type Origin = Coordinate

    type Screen =
        { Rectangle : Rectangle
          Origin : Origin
          Coordinate : Coordinate }
    
    type Cartesian =
        { Rectangle : Rectangle
          Origin : Origin
          Coordinate : Coordinate }
    

    let createCartesian (rectangle: Rectangle) (origin: Origin) (x: float) (y: float) : Cartesian =
        {
            Cartesian.Rectangle = rectangle
            Cartesian.Origin = origin
            Cartesian.Coordinate =
                { Coordinate.X = x; Y = y }
        }
    

    [<RequireQualifiedAccess>]
    module Screen =
        let create (rectangle: Rectangle) (origin: Origin) (x: float) (y: float) : Screen =
            {
                Screen.Rectangle = rectangle
                Screen.Origin = origin
                Screen.Coordinate =
                    { Coordinate.X = x; Y = y }
            }
        
        let toCartesian (origin: Origin) (screen: Screen) : Cartesian =
            let x' = screen.Coordinate.X + (screen.Origin.X - origin.X)
            let y' = -screen.Coordinate.Y - (screen.Origin.Y - origin.Y)
            createCartesian screen.Rectangle origin x' y'
        
        let ofCartesian (origin: Origin) (cartesian: Cartesian) : Screen =
            let x' = cartesian.Coordinate.X + (cartesian.Origin.X - origin.X)
            let y' = -cartesian.Coordinate.Y + (cartesian.Origin.Y - origin.Y)
            create cartesian.Rectangle origin x' y'
    

    [<RequireQualifiedAccess>]
    module Cartesian =
        let create = createCartesian
        
        let toScreen = Screen.ofCartesian
        
        let ofScreen = Screen.toCartesian
