CSC = mcs
RUN = mono

all:out.data.txt plot.a.svg plot.c.svg

out.data.txt:main.exe
	$(RUN) $< >$@

main.exe:main.cs matlib.dll
	$(CSC) -reference:matlib.dll $<

matlib.dll: \
	../../homework/linear/QRGS.cs \
	../../homework/linear/matrix.cs \
	../../homework/linear/vector.cs \
	../../homework/LeastSq/fit.cs
	$(CSC) -target:library -out:./$@ $^

plot.a.svg:out.data.txt Makefile
	echo '\
		set term svg background "white";\
		set out "$@";\
		set title "Decay of ThX";\
		set xlabel "Time, days";\
		set ylabel "Activity, relative units";\
		set key left;\
		plot []\
		"$<" using 1:2 with lines linetype 1 title "Fit"\
		,"$<" using 1:3:4 with yerrorbars pointtype 5 title"Data points"\
		'|gnuplot

plot.c.svg:out.data.txt Makefile
	echo '\
		set term svg background "white";\
		set out "$@";\
		set title "Decay of ThX";\
		set xlabel "Time, days";\
		set ylabel "Activity, relative units ";\
		set key left;\
		plot []\
		"$<" using 1:2 with lines linetype 1 title "Fit"\
		,"$<" using 1:3:4 with yerrorbars pointtype 5 title"Data points"\
		,"$<" using 1:5 with lines linetype 5 title "Fit + errors"\
		,"$<" using 1:6 with lines linetype 5 title "Fit - errors"\
		'|gnuplot

clean:
	$(RM) *.dll *.exe *.txt *.svg

