CSC = mcs
RUN = mono

all: Plot.mc.error.svg Plot.mc.integral.svg Plot.mc.test.error.svg Plot.mc.test.integral.svg Plot.mcqr.error.svg Plot.mcqr.integral.svg Out.test.txt Out.MCplain.txt Out.MCQR.txt

Out.test.txt: main.exe
	>$@
	for N in $$(seq 200 200 10000);\
		do echo $$N; $(RUN) main.exe -MC_type:"MC_test"  -N:$$N >> $@;\
	done

Out.MCplain.txt: main.exe
	>$@
	for N in $$(seq 200 200 10000);\
		do echo $$N; $(RUN) main.exe -MC_type:"MC_HW"  -N:$$N >> $@;\
	done

Out.MCQR.txt: main.exe
	>$@
	for N in $$(seq 200 200 10000);\
		do echo $$N; $(RUN) main.exe -MC_type:"MC_QR"  -N:$$N >> $@;\
	done


main.exe: main.cs matlib.dll
	$(CSC) -target:exe -reference:matlib.dll $<

matlib.dll: ../linear/vector.cs
	$(CSC) -target:library -out:$@ $<

clean:
	rm -f *.dll *.exe *.svg *.txt

Plot.mc.test.error.svg: Out.test.txt Makefile
	echo '\
	set term svg background "white";\
	set out "$@";\
	set title "Integration error on test, using plain MC";\
	set tics out;\
	set xlabel "N [#sampling points]";\
	set ylabel "error";\
	a=1; f(n)= a/sqrt(n);\
	fit f(x) "$<" index 0 using 1:4 via a;\
	plot \
	"$<" index 0 using 1:3 with lines title "Statistic estimation of error"\
	,"$<" index 0 using 1:4 with linespoints title "Actual error"\
	,f(x) with lines title "1/sqrt(n) fit to actual error"\
	'| gnuplot

Plot.mc.test.integral.svg: Out.test.txt Makefile
	echo '\
	set term svg background "white";\
	set out "$@";\
	set title "Area of unit-circle by integration , using plain MC";\
	set tics out;\
	set xlabel "N [#sampling points]";\
	set ylabel "Integral value";\
	plot \
	"$<" index 0 using 1:2 with linespoints title "plain MC integration"\
	,pi with lines title "Exact"\
	'| gnuplot

Plot.mc.error.svg: Out.MCplain.txt Makefile
	echo '\
	set term svg background "white";\
	set out "$@";\
	set title "Integration error, using plain MC";\
	set tics out;\
	set xlabel "N [#sampling points]";\
	set yrange [0:0.6];\
	set ylabel "error";\
	a=1; f(n)= a/sqrt(n);\
	fit f(x) "$<" using 1:4 via a;\
	plot \
	"$<" using 1:3 with lines title "Statistic estimation of error"\
	,"$<" using 1:4 with linespoints title "Actual error"\
	,f(x) with lines title "1/sqrt(n) fit to actual error"\
	'| gnuplot

Plot.mc.integral.svg: Out.MCplain.txt Makefile
	echo '\
	set term svg background "white";\
	set out "$@";\
	set title "Solution to homework integral, using plain MC";\
	set tics out;\
	set xlabel "N [#sampling points]";\
	set ylabel "Integral value";\
	plot \
	"$<" using 1:2 with linespoints title "Plain MC integration"\
	,1.3932039296856768591842462603255 with lines title "Exact"\
	'| gnuplot

Plot.mcqr.error.svg: Out.MCQR.txt Makefile
	echo '\
	set term svg background "white";\
	set out "$@";\
	set title "Integration error, using quasi-random MC";\
	set tics out;\
	set xlabel "N [#sampling points]";\
	set ylabel "error";\
	plot \
	"$<" using 1:3 with lines title "Error found by different sequences"\
	,"$<" using 1:4 with lines title "Actual error"\
	,"$<" using 1:5 with lines title "Error-difference between QR and SR MC" \
	'| gnuplot

Plot.mcqr.integral.svg: Out.MCQR.txt Makefile
	echo '\
	set term svg background "white";\
	set out "$@";\
	set title "Area of unit circle, using quasi-random MC";\
	set tics out;\
	set xlabel "N [#sampling points]";\
	set ylabel "Integral value";\
	plot \
	"$<" using 1:2 with lines title "QR MC integration"\
	,pi with lines title "Exact"\
	'| gnuplot
