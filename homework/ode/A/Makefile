all: Out.txt
	make ode.png

ode.png: ode.gpi Data.txt
	pyxplot $<

Out.txt Data.txt: main.exe
	mono $< 1>Out.txt 2>Data.txt

main.exe: main.cs ode.dll vector.dll
	mcs $< -target:exe -reference:vector.dll,ode.dll -out:$@

ode.dll: ode.cs vector.dll
	mcs $< -target:library -reference:vector.dll -out:$@	

MATHDIR = ~/repos/Praktisk-programmering/matlib
vector.dll: $(MATHDIR)/vector.cs
	mcs -target:library -out:./$@ $^

clean:
	rm -r data.txt *.dll *.exe *.png