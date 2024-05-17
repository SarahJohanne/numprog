CSC=mcs
RUN=mono

all:out.data.txt plots.svg 

out.data.txt:main.exe
	$(RUN) $< >$@

main.exe:main.cs sfuns.dll
	$(CSC) -reference:sfuns.dll $<

sfuns.dll:sfuns.cs
	$(CSC) -target:library -out:./$@ $^

plots.svg:out.data.txt Makefile
		echo '\
		set term svg;\
		set out "$@";\
		set title "errorfunction, gammafunction and lngammafunction";\
		set xlabel "x";\
		set ylabel "y";\
		set key left;\
		plot []\
		"$<" index 0 using 1:2 with lines title "error-function"\
		,"$<" index 1 using 1:2 with lines title "gamma-function"\
		,"$<" index 2 using 1:2 with lines title "lngamma-function"\
		'|gnuplot


clean:
	$(RM) *.exe *.dll *.txt *.svg
