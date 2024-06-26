CSC = mcs
RUN = mono

all: out.data.txt

main.exe: main.cs matlib.dll
	$(CSC) -target:exe -reference:matlib.dll $<

matlib.dll: ../linear/QRGS.cs ../linear/matrix.cs ../linear/vector.cs roots.cs
	$(CSC) -target:library -out:./$@ $^



out.data.txt: main.exe
	$(RUN) $< >$@

clean:
	rm -f *.txt *.exe *.dll *svg
