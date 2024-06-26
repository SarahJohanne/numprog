CSC = mcs
RUN = mono

all: out.data.txt Plot.Higgs.svg

main.exe: main.cs matlib.dll ../ODE/genlist.cs
	$(CSC) -target:exe -out:main.exe -reference:matlib.dll main.cs ../ODE/genlist.cs

matlib.dll: ../linear/QRGS.cs ../linear/matrix.cs ../linear/vector.cs minimize.cs 
	$(CSC) -target:library -out:./$@ $^



out.data.txt: main.exe
	mono main.exe < higs-data.txt 1> out.data.txt 2> log

clean:
	rm -f out* *.exe *.dll *svg

Plot.Higgs.svg: out.data.txt Makefile
	echo '\
	set term svg background "white";\
	set out "$@";\
	set title "The Higgs boson";\
	set tics out;\
	set xlabel "Energy [GeV/c^2]";\
	set ylabel "Signal";\
	plot \
	"$<" index 2 with lines title "Breit-Wigner fit"\
	,"higs-data.txt" using 1:2:3 with errorbars title "Experimental data"\
	'| gnuplot	