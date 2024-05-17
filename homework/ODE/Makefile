CSC=mcs
RUN=mono

all:out.data.txt testplot.svg fricplot.svg rel_i.svg

out.data.txt:main.exe
	$(RUN) $< >$@

main.exe:main.cs matlib.dll
	$(CSC) -reference:matlib.dll $<

matlib.dll: \
	../../homework/linear/vector.cs \
	../../homework/Splines/spline.cs \
	../../homework/ODE/genlist.cs \
	../../homework/ODE/ode.cs
	$(CSC) -target:library -out:./$@ $^

testplot.svg:out.data.txt Makefile
	echo '\
		set terminal png background "white";\
		set term svg;\
		set out "$@";\
		set title "Pendulum without friction";\
		set xlabel "x";\
		set ylabel "u";\
		set key right;\
		plot []\
		"$<" index 0 using 1:2 with points pointtype 4\
		'|gnuplot

fricplot.svg:out.data.txt Makefile
	echo '\
		set terminal png background "white";\
		set term svg;\
		set out "$@";\
		set title "Pendulum with friction";\
		set xlabel "t";\
		set ylabel "theta";\
		set key right;\
		plot []\
		"$<" index 1 using 1:2 with lines title "theta(t)"\
		,"$<" index 1 using 1:3 with lines title "omega(t)"\
		'|gnuplot

rel_i.svg:out.data.txt Makefile
	echo '\
		set terminal png background "white";\
		set term svg;\
		set out "$@";\
		set title "Pendulum without friction";\
		set xlabel "x";\
		set ylabel "u";\
		set key right;\
		plot []\
	#	"$<" index 2 using (1/$2)*cos($1):(1/$2)*sin($1) with lines notitle\
		"$<" index 2 using 1:2 with lines notitle\
		'|gnuplot


clean:
	$(RM) *.dll *.exe *.txt *.svg
