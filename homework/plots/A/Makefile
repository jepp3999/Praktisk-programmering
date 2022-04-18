all: erf.gnuplot.png

erf.gnuplot.png: erf.pyxplot.png Makefile
	cat log.pyx.gpi | sed  's/pyxplot/gnuplot/' | tee log.gnu.gpi | gnuplot

erf.pyxplot.png: erf.data.txt erf.tab.txt
	echo '\
	set terminal png ;\
	set output "$@" ;\
	set xlabel "$$x$$" ;\
	set ylabel "$$y$$" ;\
	set tics out ;\
	set title "Error function" ;\
	set key left top ;\
	plot [-2:2] [-1:1] "$<" index 0 using 1:2 with lines title "Error function",\
	"erf.tab.txt" using 1:2 with points pointtype 2 title "Tabulated data" \
	'| tee log.pyx.gpi | pyxplot

erf.tab.txt: Makefile
	>$@
	echo 0	0 >>$@
	echo 0.2	0.222702589 >>$@
	echo 0.4	0.428392355 >>$@
	echo 0.8	0.742100965 >>$@
	echo 0.9	0.796908212 >>$@
	echo 1.2	0.910313978 >>$@
erf.data.txt: main.exe
	mono $< > $@

all: Out.txt
	cat $<

Out.txt: main.exe
	 mono main.exe > Out.txt

main.exe: main.cs
	mcs -target:exe -out:$@ $<

clean:
	rm -f main.exe Out.txt

