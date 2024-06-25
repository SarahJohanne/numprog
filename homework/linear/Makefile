
CSC = mcs
RUN = mono

all: Out.txt Outtimes.txt Plot.times.svg

main.exe: main.cs matlib.dll
	$(CSC) -target:exe -reference:matlib.dll $<

timing.exe: timing.cs matlib.dll
	$(CSC) -target:exe -reference:matlib.dll $<

matlib.dll: vector.cs matrix.cs QRGS.cs
	$(CSC) -target:library -out:$@ $^

Outtimes.txt: timing.exe
	>$@
	for N in $$(seq 100 20 800); do \
		time --format "$$N %e" --output $@ --append \
		mono $< -size:$$N 1>out 2>err ;\
		done

Out.txt: main.exe
	mono $< > $@


# Clean compiled files
clean:
	rm -f *.dll *.exe [Oo]ut*

Plot.times.svg: Outtimes.txt Makefile
	echo '\
	set term svg background "white";\
	set out "$@";\
	set title "QR-factorization time as function of matrix size";\
	set tics out;\
	set xlabel "Matrix size N";\
	set ylabel "QR-decomposition time";\
	a=1; b=1; c=3; f(x)= b+(x/a)**(c);\
	fit f(x) "$<" via a,b;\
	plot "$<" with linespoints title "Running times"\
	,f(x) with lines title sprintf("fit: (N/%.f)^{%.2f}+%.3f",a,c,b) \
	'| gnuplot