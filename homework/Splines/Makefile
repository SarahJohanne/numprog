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
		set term svg;\
		set out "$@";\
		set title "Spline";\
		set xlabel "x";\
		set ylabel "y";\
		set key left;\
		plot []\
		"$<" index 0 using 1:2 with lines title "interpolated points"\
		,"$<" index 0 using 1:3 with lines title "integrated, interpolated points"\
		,"$<" index 1 using 1:2 with points pointtype 4 title "cos(x)"\
		,"$<" index 1 using 1:3 with points pointtype 6 title "sin(x)"\
		'|gnuplot

plot_qspline.svg: out.data.txt Makefile
		echo '\
		set term svg;\
		set out "$@";\
		set title "QSpline";\
		set xlabel "x";\
		set ylabel "y";\
		set key left;\
		plot []\
		"$<" index 2 using 1:2 with lines title "interpolated points"\
		,"$<" index 2 using 1:4 with lines title "integrated points"\
		,"$<" index 2 using 1:3 with lines title "differentiated points"\
		,"$<" index 1 using 1:2 with points pointtype 4 title "cos(x)"\
		,"$<" index 1 using 1:3 with points pointtype 5 title "sin(x)"\
		, "$<" index 1 using 1:4 with points pointtype 6 title "-sin(x)"\
		'|gnuplot

clean:
	$(RM) *.dll *.exe *.txt *.svg
