CSC = mcs
RUN = mono

all: Plot.erf.svg Out.txt

Out.txt: main.exe
	$(RUN) $< >$@
out.erf.data.txt: main_erf.exe
	$(RUN) $< 1> $@ 2> log_erf

main.exe:main.cs matlib.dll
	$(CSC) -out:$@ -reference:matlib.dll $<

main_erf.exe: main_erf.cs matlib.dll
	$(CSC) -out:$@ -reference:matlib.dll $<

matlib.dll: integrate.cs
	$(CSC) -target:library -out:$@ $^

clean:
	rm -f *.dll *.exe

Plot.erf.svg: out.erf.data.txt Makefile
	echo '\
	set term svg background "white";\
	set out "$@";\
	set title "erf(x) as integral representation";\
	set key out;\
	set tics out;\
	set grid;\
	set xlabel "x";\
	plot [][-1.5:1.5]\
	"$<" index 0 using 1:2 with line title "erf(x)" \
	,"$<" index 1 using 1:2 with points pt 5 title "table" \
	'|gnuplot

