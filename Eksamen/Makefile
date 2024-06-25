CSC = mcs
RUN = mono

all: Out.txt Plot.B1.svg Plot.Interpolations.svg Plot.Interpolations.test.svg

Out.txt: main.exe
	$(RUN) $< >$@

main.exe: main.cs interps.dll
	$(CSC) -reference:interps.dll $<

interps.dll: ../Eksamen/interps.cs
	$(CSC) -target:library -out:./$@ $<

clean:
	rm -f *.dll *.exe *.txt *.svg

Plot.B1.svg: Out.txt Makefile
	echo '\
	set term svg background "white";\
	set out "$@";\
	set title "Interpolation between points using Berrut B1";\
	set tics out;\
	set xlabel "x";\
	set ylabel "y";\
	a=1; f(n)= a*cos(n);\
	fit f(x) "$<" index 1 using 1:2 via a;\
	plot \
	"$<" index 0 using 1:2 with lines title "B1"\
	,f(x) with lines title "1*cos(x) fit to tabulated points"\
	,"$<" index 1 using 1:2 with points title "tabulated points"\
	'| gnuplot

Plot.Interpolations.test.svg: Out.txt Makefile
	echo '\
	set term svg background "white";\
	set out "$@";\
	set title "Interpolation between points using different interpolation methods";\
	set tics out;\
	set xlabel "x";\
	set ylabel "y";\
	plot \
	"$<" index 2 using 1:2 with lines title "B1"\
	,"$<" index 3 using 1:2 with lines title "Polynomial"\
	'| gnuplot

Plot.Interpolations.svg: Out.txt Makefile
	echo '\
	set term svg background "white";\
	set out "$@";\
	set title "Interpolation between points using different interpolation methods";\
	set tics out;\
	set xlabel "x";\
	set ylabel "y";\
	plot \
	"$<" index 4 using 1:2 with lines title "B1"\
	,"$<" index 5 using 1:2 with lines title "Polynomial"\
	,"$<" index 6 using 1:2 with points title "tabulated points"\
	'| gnuplot
