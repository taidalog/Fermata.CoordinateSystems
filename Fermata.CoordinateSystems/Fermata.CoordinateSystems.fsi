namespace Fermata
    
    module CoordinateSystems =
        
        type Rectangle =
            {
              Width: float
              Height: float
            }
        
        type Point =
            {
              X: float
              Y: float
            }
        
        type Origin = Point
        
        type Screen =
            {
              Rectangle: Rectangle
              Origin: Origin
              Point: Point
            }
        
        type Cartesian =
            {
              Rectangle: Rectangle
              Origin: Origin
              Point: Point
            }
        
        val createCartesian:
          rectangle: Rectangle ->
            origin: Origin -> x: float -> y: float -> Cartesian
        
        [<RequireQualifiedAccess>]
        module Screen =
            
            /// <summary>Builds a new <c>Screen</c> record.</summary>
            /// 
            /// <param name="rectangle">A <c>Rectangle</c> record which the built <c>Screen</c> point lies within.</param>
            /// 
            /// <param name="origin">An <c>Origin</c> record to be used for the built <c>Screen</c> record.
            /// <c>Origin</c> has to be given in the screen coordinate format,
            /// in which (0, 0) is the upper left corner, x-coordinate grows as it goes right, and y-coordinate grows as it goes down.</param>
            /// 
            /// <param name="x">The x-coordinate for the built <c>Screen</c> record.</param>
            /// 
            /// <param name="y">The y-coordinate for the built <c>Screen</c> record.</param>
            /// 
            /// <returns>The result <c>Screen</c> record.</returns>
            /// 
            /// <example id="screen-create-1">
            /// <code lang="fsharp">
            /// let rect = { Rectangle.Width = 200.; Height = 100. }
            /// let origin = { Origin.X = 0.; Y = 0. }
            /// Screen.create rect origin 120. 80.
            /// </code>
            /// Evaluates to the record below:
            /// <code lang="fsharp">
            /// Screen = { Rectangle = { Width = 200.0
            ///                          Height = 100.0 }
            ///            Origin = { X = 0.0
            ///                       Y = 0.0 }
            ///            Point = { X = 120.0
            ///                      Y = 80.0 } }
            /// </code>
            /// </example>
            val create:
              rectangle: Rectangle ->
                origin: Origin -> x: float -> y: float -> Screen
            
            /// <summary>Builds a new <c>Cartesian</c> record from the given <c>Screen</c> record.</summary>
            /// 
            /// <param name="origin">An <c>Origin</c> record to be used for the built <c>Cartesian</c> record.
            /// Though it is for the Cartesian coordinate, <c>Origin</c> has to be given in the screen coordinate format,
            /// in which (0, 0) is the upper left corner, x-coordinate grows as it goes right, and y-coordinate grows as it goes down.</param>
            /// 
            /// <param name="screen">The input <c>Screen</c> record.</param>
            /// 
            /// <returns>The result <c>Cartesian</c> record.</returns>
            /// 
            /// <example id="tocartesian-1">
            /// <code lang="fsharp">
            /// let rect = { Rectangle.Width = 200.; Height = 100. }
            /// let screenOrigin = { Origin.X = 0.; Y = 0. }
            /// let s = Screen.create rect screenOrigin 120. 80.
            /// 
            /// let cartesianOrigin = { Origin.X = 100.; Y = 50. }
            /// s |> Screen.toCartesian cartesianOrigin
            /// </code>
            /// Evaluates to the record below:
            /// <code lang="fsharp">
            /// Cartesian = { Rectangle = { Width = 200.0
            ///                             Height = 100.0 }
            ///               Origin = { X = 100.0
            ///                          Y = 50.0 }
            ///               Point = { X = 20.0
            ///                         Y = -30.0 } }
            /// </code>
            /// </example>
            /// 
            /// <example id="tocartesian-2">
            /// <code lang="fsharp">
            /// let rect = { Rectangle.Width = 200.; Height = 100. }
            /// let screenOrigin = { Origin.X = 0.; Y = 0. }
            /// let s = Screen.create rect screenOrigin 120. 80.
            /// 
            /// let cartesianOrigin =
            ///     {
            ///         Origin.X = rect.Width / 2. |> int |> float
            ///         Origin.Y = rect.Height / 2. |> int |> float
            ///     }
            /// s |> Screen.toCartesian cartesianOrigin
            /// </code>
            /// Evaluates to the record below:
            /// <code lang="fsharp">
            /// Cartesian = { Rectangle = { Width = 200.0
            ///                             Height = 100.0 }
            ///               Origin = { X = 100.0
            ///                          Y = 50.0 }
            ///               Point = { X = 20.0
            ///                         Y = -30.0 } }
            /// </code>
            /// </example>
            /// 
            /// <example id="tocartesian-3">
            /// <code lang="fsharp">
            /// let rect = { Rectangle.Width = 200.; Height = 100. }
            /// let screenOrigin = { Origin.X = 0.; Y = 0. }
            /// let s = Screen.create rect screenOrigin 120. 80.
            /// 
            /// let cartesianOrigin = { Origin.X = 50.; Y = 80. }
            /// s |> Screen.toCartesian cartesianOrigin
            /// </code>
            /// Evaluates to the record below:
            /// <code lang="fsharp">
            /// Cartesian = { Rectangle = { Width = 200.0
            ///                             Height = 100.0 }
            ///               Origin = { X = 50.0
            ///                          Y = 80.0 }
            ///               Point = { X = 70.0
            ///                         Y = 0.0 } }
            /// </code>
            /// </example>
            val toCartesian: origin: Origin -> screen: Screen -> Cartesian
            
            /// <summary>Builds a new <c>Screen</c> record from the given <c>Cartesian</c> record.</summary>
            /// 
            /// <param name="origin">An <c>Origin</c> record to be used for the built <c>Screen</c> record.
            /// <c>Origin</c> has to be given in the screen coordinate format,
            /// in which (0, 0) is the upper left corner, x-coordinate grows as it goes right, and y-coordinate grows as it goes down.</param>
            /// 
            /// <param name="cartesian">The input <c>Cartisian</c> record.</param>
            /// 
            /// <returns>The result <c>Screen</c> record.</returns>
            /// 
            /// <example id="ofcartesian-1">
            /// <code lang="fsharp">
            /// let rect = { Rectangle.Width = 200.; Height = 100. }
            /// let cartesianOrigin = { Origin.X = 100.; Y = 50. }
            /// let c = Cartesian.create rect cartesianOrigin 0. 30.
            /// 
            /// let screenOrigin = { Origin.X = 0.; Y = 0. }
            /// Screen.ofCartesian screenOrigin c
            /// </code>
            /// Evaluates to the record below:
            /// <code lang="fsharp">
            /// Screen = { Rectangle = { Width = 200.0
            ///                          Height = 100.0 }
            ///            Origin = { X = 0.0
            ///                       Y = 0.0 }
            ///            Point = { X = 100.0
            ///                      Y = 20.0 } }
            /// </code>
            /// </example>
            /// 
            /// <example id="ofcartesian-2">
            /// <code lang="fsharp">
            /// let rect = { Rectangle.Width = 200.; Height = 100. }
            /// let cartesianOrigin = { Origin.X = 50.; Y = 80. }
            /// let c = Cartesian.create rect cartesianOrigin 0. 30.
            /// 
            /// let screenOrigin = { Origin.X = 0.; Y = 0. }
            /// Screen.ofCartesian screenOrigin c
            /// </code>
            /// Evaluates to the record below:
            /// <code lang="fsharp">
            /// Screen = { Rectangle = { Width = 200.0
            ///                          Height = 100.0 }
            ///            Origin = { X = 0.0
            ///                       Y = 0.0 }
            ///            Point = { X = 50.0
            ///                      Y = 50.0 } }
            /// </code>
            /// </example>
            val ofCartesian: origin: Origin -> cartesian: Cartesian -> Screen
        
        [<RequireQualifiedAccess>]
        module Cartesian =
            
            /// <summary>Builds a new <c>Cartesian</c> record.</summary>
            /// 
            /// <param name="rectangle">A <c>Rectangle</c> record which the built <c>Cartesian</c> point lies within.</param>
            /// 
            /// <param name="origin">An <c>Origin</c> record to be used for the built <c>Cartesian</c> record.
            /// Though it is for the Cartesian coordinate, <c>Origin</c> has to be given in the screen coordinate format,
            /// in which (0, 0) is the upper left corner, x-coordinate grows as it goes right, and y-coordinate grows as it goes down.</param>
            /// 
            /// <param name="x">The x-coordinate for the built <c>Cartesian</c> record.</param>
            /// 
            /// <param name="y">The y-coordinate for the built <c>Cartesian</c> record.</param>
            /// 
            /// <returns>The built <c>Cartesian</c> record.</returns>
            /// 
            /// <example id="cartesian-create-1">
            /// <code lang="fsharp">
            /// let rect = { Rectangle.Width = 200.; Height = 100. }
            /// let origin = { Origin.X = 0.; Y = 0. }
            /// Cartesian.create rect origin 40. -20.
            /// </code>
            /// Evaluates to the record below:
            /// <code lang="fsharp">
            /// Cartesian = { Rectangle = { Width = 200.0
            ///                             Height = 100.0 }
            ///               Origin = { X = 0.0
            ///                          Y = 0.0 }
            ///               Point = { X = 40.0
            ///                         Y = -20.0 } }
            /// </code>
            /// </example>
            val create:
              rectangle: Rectangle ->
                origin: Origin -> x: float -> y: float -> Cartesian
            
            /// <summary>Builds a new <c>Screen</c> record from the given <c>Cartesian</c> record.</summary>
            /// 
            /// <param name="origin">An <c>Origin</c> record to be used for the built <c>Screen</c> record.
            /// <c>Origin</c> has to be given in the screen coordinate format,
            /// in which (0, 0) is the upper left corner, x-coordinate grows as it goes right, and y-coordinate grows as it goes down.</param>
            /// 
            /// <param name="cartesian">The input <c>Cartisian</c> record.</param>
            /// 
            /// <returns>The result <c>Screen</c> record.</returns>
            /// 
            /// <example id="toscreen-1">
            /// <code lang="fsharp">
            /// let rect = { Rectangle.Width = 200.; Height = 100. }
            /// let cartesianOrigin = { Origin.X = 100.; Y = 50. }
            /// let c = Cartesian.create rect cartesianOrigin 20. -30.
            /// 
            /// let screenOrigin = { Origin.X = 0.; Y = 0. }
            /// c |> Cartesian.toScreen screenOrigin
            /// </code>
            /// Evaluates to the record below:
            /// <code lang="fsharp">
            /// Screen = { Rectangle = { Width = 200.0
            ///                          Height = 100.0 }
            ///            Origin = { X = 0.0
            ///                       Y = 0.0 }
            ///            Point = { X = 120.0
            ///                      Y = 80.0 } }
            /// </code>
            /// </example>
            /// 
            /// <example id="toscreen-2">
            /// <code lang="fsharp">
            /// let rect = { Rectangle.Width = 200.; Height = 100. }
            /// let cartesianOrigin =
            ///     {
            ///         Origin.X = rect.Width / 2. |> int |> float
            ///         Origin.Y = rect.Height / 2. |> int |> float
            ///     }
            /// let c = Cartesian.create rect cartesianOrigin 20. -30.
            /// 
            /// let screenOrigin = { Origin.X = 0.; Y = 0. }
            /// c |> Cartesian.toScreen screenOrigin
            /// </code>
            /// Evaluates to the record below:
            /// <code lang="fsharp">
            /// Screen = { Rectangle = { Width = 200.0
            ///                          Height = 100.0 }
            ///            Origin = { X = 0.0
            ///                       Y = 0.0 }
            ///            Point = { X = 120.0
            ///                      Y = 80.0 } }
            /// </code>
            /// </example>
            /// 
            /// <example id="toscreen-3">
            /// <code lang="fsharp">
            /// let rect = { Rectangle.Width = 200.; Height = 100. }
            /// let cartesianOrigin = { Origin.X = 100.; Y = 50. }
            /// let c = Cartesian.create rect cartesianOrigin 20. -30.
            /// 
            /// let screenOrigin = { Origin.X = 20.; Y = 10. }
            /// c |> Cartesian.toScreen screenOrigin
            /// </code>
            /// Evaluates to the record below:
            /// <code lang="fsharp">
            /// Screen = { Rectangle = { Width = 200.0
            ///                          Height = 100.0 }
            ///            Origin = { X = 20.0
            ///                       Y = 10.0 }
            ///            Point = { X = 100.0
            ///                      Y = 70.0 } }
            /// </code>
            /// </example>
            val toScreen: origin: Origin -> cartesian: Cartesian -> Screen
            
            /// <summary>Builds a new <c>Cartesian</c> record from the given <c>Screen</c> record.</summary>
            /// 
            /// <param name="origin">An <c>Origin</c> record to be used for the built <c>Cartesian</c> record.
            /// Though it is for the Cartesian coordinate, <c>Origin</c> has to be given in the screen coordinate format,
            /// in which (0, 0) is the upper left corner, x-coordinate grows as it goes right, and y-coordinate grows as it goes down.</param>
            /// 
            /// <param name="screen">The input <c>Screen</c> record.</param>
            /// 
            /// <returns>The result <c>Cartesian</c> record.</returns>
            /// 
            /// <example id="ofscreen-1">
            /// <code lang="fsharp">
            /// let rect = { Rectangle.Width = 200.; Height = 100. }
            /// let screenOrigin = { Origin.X = 0.; Y = 0. }
            /// let s = Screen.create rect screenOrigin 0. 30.
            /// 
            /// let cartesianOrigin = { Origin.X = 100.; Y = 50. }
            /// Cartesian.ofScreen cartesianOrigin s
            /// </code>
            /// Evaluates to the record below:
            /// <code lang="fsharp">
            /// Cartesian = { Rectangle = { Width = 200.0
            ///                             Height = 100.0 }
            ///               Origin = { X = 100.0
            ///                          Y = 50.0 }
            ///               Point = { X = -100.0
            ///                         Y = 20.0 } }
            /// </code>
            /// </example>
            /// 
            /// <example id="ofscreen-2">
            /// <code lang="fsharp">
            /// let rect = { Rectangle.Width = 200.; Height = 100. }
            /// let screenOrigin = { Origin.X = 20.; Y = 10. }
            /// let s = Screen.create rect screenOrigin 100. 70.
            /// 
            /// let cartesianOrigin = { Origin.X = 100.; Y = 50. }
            /// Cartesian.ofScreen cartesianOrigin s
            /// </code>
            /// Evaluates to the record below:
            /// <code lang="fsharp">
            /// Cartesian = { Rectangle = { Width = 200.0
            ///                             Height = 100.0 }
            ///               Origin = { X = 100.0
            ///                          Y = 50.0 }
            ///               Point = { X = 20.0
            ///                         Y = -30.0 } }
            /// </code>
            /// </example>
            val ofScreen: origin: Origin -> screen: Screen -> Cartesian

