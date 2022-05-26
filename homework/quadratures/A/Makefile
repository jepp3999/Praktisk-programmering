all: Out.txt
	make erf.png

erf.png: erf.gpi Data.txt
	pyxplot $<

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs quadratures.dll vector.dll
	mcs $< -target:exe -reference:vector.dll,quadratures.dll -out:$@

quadratures.dll: quadratures.cs vector.dll
	mcs $< -target:library -reference:vector.dll -out:$@	

MATHDIR = ~/repos/Praktisk-programmering/matlib
vector.dll: $(MATHDIR)/vector.cs
	mcs -target:library -out:./$@ $^

clean:
	rm -r data.txt *.dll *.exe *.png