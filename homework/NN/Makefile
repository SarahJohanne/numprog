CSC = mcs
RUN = mono

all: out.data.txt Plot.ann.svg

main.exe: main.cs matlib.dll
	$(CSC) -target:exe -out:main.exe -reference:matlib.dll main.cs

matlib.dll: ../linear/QRGS.cs ../linear/matrix.cs ../linear/vector.cs nn.cs
	$(CSC) -target:library -out:./$@ $^

out.data.txt: main.exe
	$(RUN) main.exe > out.data.txt

clean:
	rm -f out* *.exe *.dll *svg

Plot.ann.svg: out.data.txt Makefile
	echo '\
		set terminal svg background "white";\
		set output "$@";\
		set title "Approximation to g(x)=Cos(5*x-1)*Exp(-x*x) using ann";\
		set xlabel "x";\
		set ylabel "g(x)";\
		set key right;\
		plot "$<" index 0 using 1:2 with points title "tabulated points",\
		     "$<" index 1 using 1:2 with lines title "nn values";\
	' | gnuplot
