all: Out.txt
	cat $<

Out.txt: main.exe input.txt
	mono main.exe -input:input.txt -output:Out.txt

main.exe: main.cs
	mcs main.cs

clean:
	rm -f Out.txt main.exe
