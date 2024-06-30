CSC=mcs
RUN=mono

all:out.data.txt plot_lspline.svg plot_qspline.svg

out.data.txt:main.exe
	$(RUN) $< >$@

main.exe:main.cs matlib.dll
	$(CSC) -reference:matlib.dll $<

matlib.dll: \
	../../homework/linear/vector.cs \
	../Splines/spline.cs
	$(CSC) -target:library -out:./$@ $^

plot_lspline.svg: out.data.txt Makefile
		echo '\
		set term svg background "white";\
		set out "$@";\
		set title "Spline";\
		set xlabel "x";\
		set ylabel "y";\
		set key right;\
		plot []\
		"$<" index 0 using 1:2 with points title "Tabulated points"\
		,"$<" index 0 using 3:4 with points title "Tabulated points, for integration"\
		,"$<" index 1 using 1:2 with lines title "Linear interpolation"\
		,"$<" index 2 using 1:2 with lines title "Integrated, linear interpolation"\
		#, cos(x) with lines title "cos(x)"\
		#, sin(x) with 	lines title "sin(x)"\
		'|gnuplot

plot_qspline.svg: out.data.txt Makefile
		echo '\
		set term svg background "white";\
		set out "$@";\
		set title "QSpline";\
		set xlabel "x";\
		set ylabel "y";\
		set key left;\
		plot []\
		"$<" index 3 using 1:2 with points title "Tabulated points"\
		,"$<" index 3 using 1:3 with points title "Tabulated points, for derrivative"\
		,"$<" index 3 using 1:4 with points title "Tabulated points, for anti-derrivative"\
		,"$<" index 4 using 1:2 with lines title "Quadratic interpolation"\
		,"$<" index 5 using 1:2 with lines title "Derivative, quadratic interpolation"\
		,"$<" index 6 using 1:2 with lines title "Integrated, quadratic interpolation"\
		'|gnuplot

clean:
	$(RM) *.dll *.exe *.txt *.svg
