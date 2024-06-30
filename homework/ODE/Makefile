CSC = mcs
RUN = mono

all: out.data.txt testplot.svg fricplot.svg cirkel.svg elipse.svg planet.svg

out.data.txt: main.exe
	$(RUN) main.exe > out.data.txt

main.exe: main.cs matlib.dll
	$(CSC) -reference:matlib.dll main.cs

matlib.dll: \
	../../homework/linear/vector.cs \
	../../homework/Splines/spline.cs \
	../../homework/ODE/genlist.cs \
	../../homework/ODE/ode.cs
	$(CSC) -target:library -out:matlib.dll $^

testplot.svg: out.data.txt Makefile
	echo '\
		set terminal svg background "white";\
		set output "$@";\
		set title "Pendulum without friction";\
		set xlabel "x";\
		set ylabel "u(x)";\
		set key right;\
		plot "$<" index 0 using 1:2 with points pointtype 4 title "ODE solution";\
	' | gnuplot

fricplot.svg: out.data.txt Makefile
	echo '\
		set terminal svg background "white";\
		set output "$@";\
		set title "Pendulum with friction";\
		set xlabel "t";\
		set key right;\
		plot "$<" index 1 using 1:2 with lines title "theta(t)",\
		     "$<" index 1 using 1:3 with lines title "omega(t)";\
	' | gnuplot

cirkel.svg: out.data.txt Makefile
	echo '\
		set terminal svg background "white";\
		set output "$@";\
		set title "Newtonian circular motion";\
		set xlabel "(1/u)*cos(phi)";\
		set ylabel "(1/u)*sin(phi)";\
		set size square;\
		set key right;\
		plot "$<" index 2 using 1:2 with lines notitle;\
	' | gnuplot

elipse.svg: out.data.txt Makefile
	echo '\
		set terminal svg background "white";\
		set output "$@";\
		set title "Newtonian elliptical motion";\
		set xlabel "(1/u)*cos(phi)";\
		set ylabel "(1/u)*sin(phi)";\
		set size square;\
		set xrange[-1.5:1.5];\
		set yrange[-0.7:2.3];\
		set key right;\
		plot "$<" index 3 using 1:2 with lines notitle;\
	' | gnuplot

planet.svg: out.data.txt Makefile
	echo '\
		set terminal svg background "white";\
		set output "$@";\
		set title "Planetary orbit";\
		set xlabel "(1/u)*cos(phi)";\
		set ylabel "(1/u)*sin(phi)";\
		set size square;\
		set key right;\
		plot "$<" index 4 using 1:2 with lines notitle;\
	' | gnuplot

clean:
	rm -f *.dll *.exe *.txt *.svg