CSC = mcs
RUN = mono

all: out.data.txt Plot.Hydrogen.svg Plot.Conv.rmin.svg Plot.Conv.rmax.svg Plot.Conv.eps.svg Plot.Conv.acc.svg

main.exe: main.cs matlib.dll
	$(CSC) -target:exe -reference:matlib.dll $<

matlib.dll: ../linear/QRGS.cs ../linear/matrix.cs ../linear/vector.cs ../ODE/genlist.cs ../ODE/ode.cs roots.cs
	$(CSC) -target:library -out:./$@ $^


out.data.txt: main.exe
	$(RUN) $< >$@

clean:
	rm -f *.txt *.exe *.dll *svg

Plot.Hydrogen.svg: out.data.txt Makefile
	echo '\
	set term svg background "white";\
	set out "$@";\
	set title "Calculated wave function for Hydrogen in lowest bound state";\
	set tics out;\
	set xlabel "r [Bohr radius]";\
	set ylabel "Reduced, radial wave function f(r)";\
	plot "$<" index 1 using 1:2 with lines title "Calculated wave function"\
	, "$<" index 2 using 1:2 with lines title "Theoretical wave function";\
	'| gnuplot

Plot.Conv.rmin.svg: out.data.txt Makefile
	echo '\
	set term svg background "white";\
	set out "$@";\
	set title "Convergence of solution with respect to rmin parameter";\
	set tics out;\
	set xrange [*:*] reverse;\
	set xlabel "r_{min}";\
	set ylabel "E_0";\
	plot "$<" index 3 using 1:2 with points title "Calculated E_0"\
	, -0.5 with lines title "Theoretical solution";\
	'| gnuplot

Plot.Conv.rmax.svg: out.data.txt Makefile
	echo '\
	set term svg background "white";\
	set out "$@";\
	set title "Convergence of solution with respect to rmax parameter";\
	set tics out;\
	set xlabel "r_{max}";\
	set ylabel "E_0";\
	plot "$<" index 4 using 1:2 with points title "Calculated E_0"\
	, -0.5 with lines title "Theoretical solution";\
	'| gnuplot

Plot.Conv.eps.svg: out.data.txt Makefile
	echo '\
	set term svg background "white";\
	set out "$@";\
	set title "Convergence of solution with respect to eps parameter";\
	set tics out;\
	set xrange [*:*] reverse;\
	set yrange [-0.5115:-0.498];\
	set xlabel "eps value";\
	set ylabel "E_0";\
	plot "$<" index 5 using 1:2 with points title "Calculated E_0"\
	, -0.5 with lines title "Theoretical solution";\
	'| gnuplot

Plot.Conv.acc.svg: out.data.txt Makefile
	echo '\
	set term svg background "white";\
	set out "$@";\
	set title "Convergence of solution with respect to acc parameter";\
	set tics out;\
	set xrange [*:*] reverse;\
	set yrange [-0.5115:-0.498];\
	set xlabel "acc value";\
	set ylabel "E_0";\
	plot "$<" index 6 using 1:2 with points title "Calculated E_0"\
	, -0.5 with lines title "Theoretical solution";\
	'| gnuplot