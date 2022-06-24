all: Out.txt
	cat Out.txt

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs LMsearch.dll lagrangeroots.dll QRGS.dll matrix.dll vector.dll
	mcs $< -target:exe -reference:LMsearch.dll,lagrangeroots.dll,QRGS.dll,matrix.dll,vector.dll -out:$@

LMsearch.dll: LMsearch.cs lagrangeroots.dll 
	mcs $< -target:library -reference:lagrangeroots.dll,QRGS.dll,matrix.dll,vector.dll -out:$@	

lagrangeroots.dll: lagrangeroots.cs QRGS.dll 
	mcs $< -target:library -reference:QRGS.dll,matrix.dll,vector.dll -out:$@	

MATHDIR = ~/repos/Praktisk-programmering/matlib
QRGS.dll: $(MATHDIR)/QRGS.cs
	mcs -target:library -reference:vector.dll,matrix.dll -out:./$@ $^

matrix.dll: $(MATHDIR)/matrix.cs
	mcs -target:library -reference:vector.dll -out:./$@ $^

vector.dll: $(MATHDIR)/vector.cs
	mcs -target:library -out:./$@ $^

clean:
	rm -r data.txt *.dll *.exe