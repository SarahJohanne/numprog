# Exam Project

## Part A:
I implemented the Berrut B1 rational function interpolation algorithm, and tested it on tabulated points from y=cos(x). See *Plot.B1.a.svg*.

## Part B + C:
I made an interpolation class containing B1 and polynomial interpolation algorithms. To show that the class did indeed work, I tested it on the same function as before, see *Plot.class.svg*. I then used the class to make interpolations for Runge's function, hence showing Runge's Phenomenon; The B1 interpolation results in a minimization of large oscillations at edges, contrary to polynomial. See *Plot.Runge.svg*. 

Furthermore, to confirm that the Berrut interpolants have a time complexity of *O(n)*, i measured the time it takes B1 to evaluate for a list of N points as a function of N.
I then plotted the time as a function of N in gnuplot and fitted it with x*N, see *Plot.times.svg*.

Total number of points: 8



