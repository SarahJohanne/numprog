out.txt : main.exe
	mono main.exe > out.txt

out2.txt : main2.exe
	mono main2.exe > out2.txt

main2.exe: main2.cs
	mcs main2.cs

main.exe: main.cs
	mcs main.cs

clean:
	rm -f out.txt main.exe out2.txt main2.exe


