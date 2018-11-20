SHELL   = /bin/sh

FILE0   = cv
TEX     = $(FILE0).tex
FILE1   = handout
HTEX    = $(FILE1).tex
HXDV    = $(FILE1).xdv
HPDF    = $(FILE1).pdf


all:
	make tex

tex:
	xelatex $(TEX)
#	make clean

handout:
	xelatex $(HTEX)
#	make clean

pw:
	pdftk $(PDF) output $(PDFOUT) owner_pw ownerpasswd user_pw userpasswd compress encrypt_128bit

help:
	echo "USAGE: make [all/tex/handout/pw/clean]"

clean:
	rm -f *.aux *.dvi *.idx *.ilg *.ind *.log *.nav *.out *.snm *.xdv *.toc *.pdf *~

