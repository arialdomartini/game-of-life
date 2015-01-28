`Capoccione`
==========

Il progetto per il Kata #1 di TicinoXP.


I requisiti
===========



1
-

Esistono 4 colori, Rosso, Nero, Verde, Giallo e un giocatore, chiamato “`Ignaro`”.
All’Avvio `Capoccione` è impostato su un elenco di 5 colori, chiamato “`Sequenza Segreta`”.
La `Sequenza Segreta` di Fabbrica è

```
rosso, verde, giallo, giallo, nero
```

Gioca `Ignaro`.
Tutto quel che l’`Ignaro` può fare con `Capoccione` è chiamare la funzione “`Arrenditi`”, per terminare il gioco.
Quando la funzione `Arrenditi` viene chiamata, `Capoccione` restituisce il testo

```
“Game over! La Sequenza Segreta era: RVGGN”
```


2
-

C’è un secondo giocatore, chiamato `Mastro` che, all’Avvio, può impostare `Capoccione` su una `Sequenza Segreta` diversa da quella di fabbrica, e poi passa `Capoccione` a `Ignaro`.
Esempi di Sequenze Segrete accettabili sono 

```
rosso, verde, giallo, giallo, giallo
verde, verde, rosso, nero, giallo
nero, nero, nero, nero, nero
```

Quando l’`Ignaro` chiama “`Arrenditi`” `Capoccione` restituisce

```
“Game over! La Sequenza Segreta era: ”
```

seguito dalle iniziali maiuscole dei colori della `Sequenza Segreta`. Per esempio 

```
rosso, verde, giallo, giallo, giallo  => RVGGG
verde, verde, rosso, nero, giallo     => VVRNG
nero, nero, nero, nero, nero          => NNNNN
```

3
-

`Mastro` non può impostare una `Sequenza Segreta` uguale a quella di fabbrica.
4
-

Invece di chiamare subito “`Arrenditi`”, `Ignaro` può usare la funzione Scommetti per avviare una Scommessa.
Con la funzione Scommetti l’`Ignaro` fornisce al `Capoccione` 5 colori, chiamati “`Sequenza Tentativo`”. L’`Ignaro` scommette che la `Sequenza Tentativo` coincida con la `Sequenza Segreta`.

Sono possibili due esiti: “`Scommessa Azzeccata`” o “`Scommessa Sbagliata`”.

Una Scommessa è Azzeccata si ha quando la `Sequenza Tentativo` è identica alla `Sequenza Segreta`; in questo caso `Capoccione` restituisce la stringa 

```
Bravone!
```

 e termina. 

Una Scommessa è Sbagliata quando  le due Sequenze non coincidono; in questo caso `Capoccione` restituisce 

```
Nada!
```

e riavvia il gioco.

Al riavvio del gioco il giocatore `Mastro` deve reimpostare una nuova `Sequenza Segreta`. 


5
-

È possibile un numero massimo di 12 `Scommesse Sbagliate`.
Alla dodicesima `Scommessa Sbagliata`, `Capoccione` restituisce la stringa 

```
Game over
```

e termina. 
Tra una scommessa e l’altra `Mastro` imposta sempre una nuova `Sequenza Segreta`.
6
-

Non deve più esistere il concetto di `Sequenza Segreta` di Fabbrica. All’avvio la sequenza deve essere sempre impostata da `Mastro`.
7
-

Due colori che occupano la stessa posizione sia nella `Sequenza Tentativo` che nella `Sequenza Segreta` si chiamano `Colori Beccati`.
In caso di `Scommessa Sbagliata`, al posto della stringa “Nada!” `Capoccione` deve restituire  il Numero dei `Colori Beccati`. Per esempio

```
Sequenza Segreta:      RRRRR
Sequenza Tentativo:    RRRRR
output:                5

Sequenza Segreta:      RRRRR
Sequenza Tentativo:    VVVVV
output:                0

Sequenza Segreta:      RRRRR
Sequenza Tentativo:    VVRVV
output:                1

Sequenza Segreta:      RVRVR
Sequenza Tentativo:    VRVRV
output:                0

Sequenza Segreta:      RVNGG
Sequenza Tentativo:    GVRGV
output:                2
```

8
-

In caso di `Scommessa Sbagliata`, al posto del Numero di `Colori Beccati`, `Capoccione` deve restituire le loro iniziali, in ordine. Per esempio:

```
Sequenza Segreta:      GGGGG
Sequenza Tentativo:    GGVGG
output:                GGGG

Sequenza Segreta:      RGRGV
Sequenza Tentativo:    RNRNV
output:                RRV
```

9
-

Tra Scommesse la `Sequenza Segreta` non viene reimpostata da `Mastro`, ma il gioco continua con la `Sequenza Segreta` impostata inizialmente dal `Mastro`.
Questo requisito corregge il requisito 4.
10
--

In caso di `Scommessa Sbagliata` al posto delle iniziali dei `Colori Beccati` `Capoccione` deve restituire tanti OK, separati da virgole, quanti sono `Colori Beccati`. Ad esempio


```
Sequenza Segreta:      GGGGG
Sequenza Tentativo:    GGVGG
output:                OK,OK,OK,OK

Sequenza Segreta:      RGRGV
Sequenza Tentativo:    RNRNV
output:                OK,OK,OK
```

11
--

Due colori presenti sia nella `Sequenza Tentativo` che nella `Sequenza Segreta` e che non occupino la stessa posizione vengono si chiamano `Colori Quasi Beccati`. Un `Colore Beccato` non è un `Colore Quasi Beccato`.

In caso di `Scommessa Sbagliata` il programma deve restituire una stringa di tanti OK separati da virgole per ogni `Colore Beccato`, seguito da una stringa di tanti QUASI, separati da virgole, per ogni `Colore Quasi Beccato`. Le due stringhe devono essere separate da uno spazio.

Esempio


```
Sequenza Segreta:      RRNNV
Sequenza Tentativo:    RRVNN
output:                OK,OK,OK QUASI,QUASI

Sequenza Segreta:      RRNNV
Sequenza Tentativo:    NGGGG
output:                _QUASI
```
12
--

`Capoccione` può essere avviato in due modalità: “`Allenamento`” o “`Partita`”. La modalità “`Partita`” è quella descritta fino ad ora. La modalità “`Allenamento`” ha due differenze: 1) la `Sequenza Segreta` e la `Sequenza Tentativo` sono lunghe 4 colori invece di 5; 2) non c’è un limite al numero di `Scommesse Sbagliate`.
 

