all: Out.txt
	cat $<

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs vec.dll
	mcs -target:exe -out:$@ $< -reference:vec.dll main.cs

vec.dll: vec.cs
	mcs -target:library -out:vec.dll vec.cs

clean:
	rm -f Out.txt main.exe
