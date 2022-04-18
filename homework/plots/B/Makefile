gam.pyxplot.png: gam.data.txt gam.tab.txt Makefile
	echo '\
	set terminal png ;\
	set output "$@" ;\
	set xlabel "$$x$$" ;\
	set ylabel "$$y$$" ;\
	set tics out ;\
	set title "Gamma function (app.)" ;\
	set key left top ;\
	plot [0:6] [0:125] "$<" index 0 using 1:2 with lines title "Gamma function",\
	"gam.tab.txt" using 1:2 with points pointtype 2 title "Tabulated data" \
	'| tee log.pyx.gpi | pyxplot

gam.tab.txt: Makefile
	>$@
	echo 1	1 >>$@
	echo 2	1 >>$@
	echo 3	2 >>$@
	echo 4  6 >>$@
	echo 5	24 >>$@
	echo 6 120 >>$@

gam.data.txt: main.exe
	mono $< > $@

all: Out.txt
	cat $<

Out.txt: main.exe
	 mono main.exe > Out.txt

main.exe: main.cs
	mcs -target:exe -out:$@ $<

clean:
	rm -f main.exe Out.txt
