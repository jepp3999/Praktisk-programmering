gam.pyxplot.png: gam.data.txt gam.tab.txt
	echo '\
	set terminal png ;\
	set output "$@" ;\
	set xlabel "$$x$$" ;\
	set ylabel "$$y$$" ;\
	set tics out ;\
	set title "error function" ;\
	set key left top ;\
	plot [-2:2] [-1:1] "$<" index 0 using 1:2 with lines title "erf($$x$$)",\
	"erf.tab.txt" using 1:2 with points pointtype 2 title "tabulated data" \
	'| tee log.pyx.gpi | pyxplot

erf.tab.txt: Makefile
	>$@
	echo 0.2	0.222702589 >>$@
	echo 0.4	0.428392355 >>$@
	echo 0.8	0.742100965 >>$@
	echo 0.9	0.796908212 >>$@

erf.data.txt: main.exe
	mono $< > $@

Out.txt: main.exe
	 mono main.exe > Out.txt

main.exe: main.cs
	mcs -target:exe -out:$@ $<

clean:
	rm -f main.exe Out.txt
gam.pyxplot.png: gam.data.txt gam.tab.txt Makefile
	echo '\
	set terminal png ;\
	set output "$@" ;\
	set xlabel "$$x$$" ;\
	set ylabel "$$y$$" ;\
	set tics out ;\
	set title "Gamma function (app.)" ;\
	set key left top ;\
	plot [0:6] [0:30] "$<" index 0 using 1:2 with lines title "Gamma function",\
	"gam.tab.txt" using 1:2 with points pointtype 2 title "Tabulated data" \
	'| tee log.pyx.gpi | pyxplot

gam.tab.txt: Makefile
	>$@
	echo 1	1 >>$@
	echo 2	1 >>$@
	echo 3	2 >>$@
	echo 4  6 >>$@
	echo 5	24 >>$@

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
