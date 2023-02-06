# Das Best Practice Dilemma

beschreibt die Situation, eine Aufgabe erledigen zu m�ssen, f�r die ich nicht �ber ausreichendes Know-How verf�ge. Hier gehe ich auf die Suche nach einer geeigneten **Best Practice**-L�sung
 um die Aufgabe wenigsten Ansatzweise l�sen zu k�nnen.
Was ist aber das Problem mit **Best Practice**? **Best Practice** unterliegen einem 
gewissen Zeitgeit. Eine L�sungen f�r eine Aufgabe von vor 10 Jahren, ist eine andere L�sung wie f�r die gleiche Aufgabe heute.
Ein weiteres Problem ist auch heraus zufinden, wie gut ist eigentlich meine gefunden L�sung.
Frei nach dem Spruch "1000 Fliegen k�nnen sich nicht irren", kann ein gefundener **Best Practice** zwar funktionieren, ist aber eben nicht die beste L�sung.
Es gibt durchaus Aspekte bei dem es tats�chlich nicht so wichtig ist, wie gute die gefundene L�sung ist, Hauptsache die gefundene L�sung funktioniert.
Bei der Programmierung kann das ein durchaus wichtiger Aspekt sein.

Hierzu ein Beispiel: 
Aufgabe ist es, eine L�sung zu finden, bei der alle Leerzeichen aus einen Text entfernt werden kann.
Die L�sung soll in C# mit einem dazu passendem Benchmark umgesetzt werden.

Die Beispiele zeigen verschiedene L�sungen, die alle die Aufgabe erf�llen, aber auch ihre spezifischen Probleme aufweisen.

| Variante       | Zeit in ms |
| -------------- | ---------- |
| STRING.REPLACE | 39         |
| LINQ           | 355        |

Die Werte sind von der Umgebung und dem PC abh�ngig, zu sehen ist aber, das es hier Werte gibt, die stark von einander abweichen.
Auch nicht jede Variante f�hrt zum gew�nschtem Ergebnis.

| Variante        | Zeit in ms |
| --------------- | ---------- |
| STRING.REPLACE  | 39         |

```csharp
return str.Replace(" ", string.Empty);
```
Diese Variante ber�cksichtig nur einfache Leerzeichen (String.Empty), dass ist aber nicht immer so gew�nscht ist.

Das Dilemma besteht nun darin, zwischen den verschiedenen Varianten f�r

* Performance
* Lesbarkeit
* Sicherheit (unsafe)

auszuw�hlen. Die verschiedene Varianten stellen f�r die Aufgabe unterschiedliche L�sungen zu Verf�gung.
So kann es schnell vorkommen, f�r **Best Practice** eine eher einfache Variante zu w�hlen, und je nach Programmierkenntnisse damit auch 
eine weniger geeignete L�sung.

<img src="./TrimVarianten.png" style="width:450px;"/>

Die Tabelle zeigt die verschiedenen Varianten mit ihren Ausf�hrungszeiten. Die Auswirkungen der verschiedenen Varianten wird
 am besten bei einer hohen Anzahl von Zeichen deutlich.

