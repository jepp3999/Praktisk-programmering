Odeint.png: Out.txt Makefile
	echo '\
	set terminal png ;\
	set output "$@" ;\
	set xlabel "$$t$$" ;\
	set title "Error function";\
	set ticks out;\
	set key bottom right;\
	set grid;\
	plot [-0.2: 10.2] [-4.2: 3.6] "$<" index 0 using 1:2 with lines title "theta(t)",\ \n\
	"$<" using 1:3 with lines title "omega(t)"\
	'| tee log.gpi | pyxplot

Out.txt: main.exe
	mono $< > $@

main.exe: main.cs vector.dll ode.dll
	mcs -target:exe -reference:vector.dll -reference:ode.dll -out:$@ $<

ode.dll:ode.cs vector.dll
	mcs -target:library -reference:vector.dll -out:$@ $<

vector.dll: vector.cs
	mcs -target:library -out:$@ $<

