complex.pyxplot.png: gam.data.txt Makefile
	echo '\
	set terminal png ;\
	set output "$@" ;\
	set xlabel "$$Re(z)$$" ;\
	set ylabel "$$Im(z)$$" ;\
	set zlabel "$$abs(\Gamma(z))$$" ;\
	set title "Gamma function" ;\
	set ticks out ;\
	set key below ;\
	plot 3d [-5: 5] [-5: 5] [0: 6] "$<" index 0 using 1:2:3 with surface col black fillcol blue title "Complex Gamma function" \n\
	'| tee log.gpi | pyxplot

gam.data.txt: main.exe
	mono $< > $@

all: Out.txt
	cat $<

Out.txt: main.exe
	 mono main.exe > Out.txt

main.exe: main.cs cmath.dll
	mcs -reference:cmath.dll main.cs

CMATHDIR = ~/repos/Praktisk-programmering/exercises/complex
cmath.dll: $(CMATHDIR)/cmath.cs $(CMATHDIR)/complex.cs
	mcs -target:library -out:./cmath.dll $^

clean:
	rm -f main.exe Out.txt
