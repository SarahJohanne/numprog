CSC = mcs
RUN = mono

all: Out.txt Plot.B1.a.svg Outtimes.txt Plot.times.svg Plot.Runge.svg Plot.class.svg

Out.txt: main.exe
	$(RUN) $< >$@

Outtimes.txt: timing.exe
	>$@
	for N in $$(seq 10000 10000 500000); do \
		time --format "$$N %e" --output $@ --append \
		mono $< -size:$$N 1>out 2>err ;\
		done

main.exe: main.cs interps.dll
	$(CSC) -target:exe -reference:interps.dll $<

timing.exe: timing.cs interps.dll
	$(CSC) -target:exe -reference:interps.dll $<

interps.dll: ../Eksamen/interps.cs
	$(CSC) -target:library -out:./$@ $<

clean:
	rm -f *.dll *.exe *.txt *.svg *log

Plot.B1.a.svg: Out.txt Makefile
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

Plot.class.svg: Out.txt Makefile
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
	,"$<" index 1 using 1:2 with points title "tabulated points"\
	'| gnuplot

Plot.Runge.svg: Out.txt Makefile
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

Plot.times.svg: Outtimes.txt Makefile
	echo '\
	set term svg background "white";\
	set out "$@";\
	set title "Berrut-1 calculation time as function of sample size";\
	set tics out;\
	set xlabel "N";\
	set ylabel "Calculation time";\
	a=0.0000006; b=0.05; f(x)= a*x + b;\
	fit f(x) "$<" via a,b;\
	plot "$<" with linespoints title "Running times"\
	,f(x) with lines title sprintf("fit: (N*%.8f)+%.3f",a,b) \
	'| gnuplot