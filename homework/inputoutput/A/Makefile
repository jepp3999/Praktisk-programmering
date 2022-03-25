all: Out.txt
	cat $<

Out.txt: main.exe
	echo 0 1 2 3 4 5 > input.txt
	mono main.exe < input.txt > Out.txt

main.exe: main.cs
	mcs main.cs

clean:
	rm -f Out.txt main.exe
