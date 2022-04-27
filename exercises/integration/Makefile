Erf.pyxplot.png: Out.txt Makefile
	echo '\
	set terminal png ;\
	set output "$@" ;\
	set xlabel "$$x$$" ;\
	set ylabel "$$y$$" ;\
	set title "Error function";\
	set ticks out;\
	set key top left;\
	set grid;\
	plot [-3: 3] [-1.2: 1.2] "$<" index 0 using 1:2 with lines title "Error function" \n\
	'| tee log.gpi | pyxplot

Out.txt: main.exe
	mono $< > $@

int_result.txt: int.exe
	mono $< > $@

int.exe: int.cs integrate.dll
	mcs -target:exe -reference:integrate.dll -out:$@ $<

main.exe: main.cs integrate.dll
	mcs -target:exe -reference:integrate.dll -out:$@ $<

integrate.dll: integrate.cs
	mcs -target:library -out:$@ $<
