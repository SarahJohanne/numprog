CSC = mcs
RUN = mono

all: out.data.txt

main.exe: main.cs rootlib.dll
	$(CSC) -reference:rootlib.dll $<

matlib.dll: ../linear/QRGS.cs ../linear/matrix.cs ../linear/vector.cs
	$(CSC) -target:library -out:./$@ $<

rootlib.dll: ../roots/roots.cs
	$(CSC) -target:library -out:./$@ $<

roots.exe: roots.cs matlib.dll
	$(CSC) -reference matlib.dll $<

out.data.txt: main.exe
	$(RUN) $< >$@

clean:
	rm -f *.txt *.exe *.dll *svg
