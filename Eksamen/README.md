```mermaid
classDiagram
    class Interpolator {
        <<interface>>
        +interpolate(x: double): double
        +add_point(x: double, y: double): void
    }

    class CubicSpline {
        +interpolate(x: double): double
        +add_point(x: double, y: double): void
    }

    class Polynomial {
        +interpolate(x: double): double
        +add_point(x: double, y: double): void
    }

    class Barycentric {
        +interpolate(x: double): double
        +add_point(x: double, y: double): void
    }

    Interpolator <|-- CubicSpline
    Interpolator <|-- Polynomial
    Interpolator <|-- Barycentric
    ```
    