CSC = mcs
RUN = mono

all:E0.dr.svg E0.rmax.svg f0.svg out.a.txt

maina.exe:maina.cs matlib.dll
	$(CSC) -reference:matlib.dll $<

mainb.exe:mainb.cs matlib.dll
	$(CSC) -reference:matlib.dll $<

E0.dr.svg:out.E0.dr.txt Makefile
	echo '\
	set term svg background "white";\
	set out "$@";\
	set title "Hydrogen, matrix, E_0 convergence with dr";\
	set xlabel "dr, Bohr radius";\
	set xrange [*:*] reverse ;\
	set ylabel "E_{0}, Hartree";\
	set key left;\
	plot []\
	 "$<" using 2:3 with linespoints pointtype 5 title "calculated points"\
	'|gnuplot

E0.rmax.svg:out.E0.rmax.txt Makefile
	echo '\
	set term svg background "white";\
	set out "$@";\
	set title "Hydrogen, matrix, E_0 convergence with rmax";\
	set xlabel "rmax, Bohr radius";\
	set ylabel "E_{0}, Hartree";\
	set key left;\
	plot []\
	 "$<" using 1:3 with linespoints pointtype 5 title "calculated points"\
	'|gnuplot

f0.svg:out.f0.txt Makefile
	echo '\
	set term svg background "white";\
	set out "$@";\
	set xlabel "r, Bohr radius";\
	set ylabel "f(r), arb. u.";\
	set title "Hydrogen atom ground state radial wave-function";\
	plot\
	 "$<" index 0 using 1:2 with points pointtype 7 pointsize 0.5 title "calculated w. rmax=6"\
	,"$<" index 1 using 1:2 with points pointtype 7 pointsize 0.5 title "calculated w. rmax=9"\
	,"$<" index 2 using 1:2 with points pointtype 7 pointsize 0.5 title "calculated w. rmax=4"\
	,"$<" index 0 using 1:3 with lines title "exact"\
	'| gnuplot

out.E0.dr.txt:mainb.exe
	>$@
	for dr in 0.02 0.03 0.04 0.05 0.1 0.15 0.2 0.25; do \
		echo $$dr; $(RUN) mainb.exe -rmax:6 -plot:"E0" -dr:$$dr 2>/dev/null 1>>$@ \
	; done

out.E0.rmax.txt:mainb.exe
	>$@
	for rmax in 6 7 8 9 10 11 12; do \
		echo $$rmax; $(RUN) mainb.exe -dr:0.3 -plot:"E0" -rmax:$$rmax 2>/dev/null 1>>$@ \
	; done

out.f0.txt:mainb.exe
	>$@
	for rmax in 6 9 4; do \
		echo $$rmax; $(RUN) mainb.exe -dr:0.3 -plot:"f0" -rmax:$$rmax 2>/dev/null 1>>$@ \
	; done

out.a.txt: maina.exe
	$(RUN) $< > $@

matlib.dll: \
	../../homework/linear/QRGS.cs \
	../../homework/linear/matrix.cs \
	../../homework/linear/vector.cs \
	../../homework/EVD/jacobi.cs
	$(CSC) -target:library -out:./$@ $^

clean:
	$(RM) *.dll *.exe *.txt


