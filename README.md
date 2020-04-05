# USE - Unified System for Education

## Bevezetés

Oktató szoftverünk egyik pillére a mesterséges intelligencia alapú feladat kiértékelés. Programunk, mely jelenleg konzol applikációként működik, egy webes felületen kérdésekre leadott válaszokat elemzi és visszajelez a válasz helyességét illetően.
A megoldás innovativitása abban rejlik, hogy a tanulóktól nem pontos egyezés alapú válaszokat kérünk, egy tanító halmaz alapján betanított algoritmus végzi a javítást. Ez alapján számon kérhető olyan tudás, mely a kontakt órák hiányában nehezebbé vált.

Az eredeti tanító halmaz a tanár által kérdésre adott válasz, melyeket ki lehet egészíteni a válasz szövegében lévő szavak szinonímáival. A betanulás végeztével egy adott pontossággal meg tudjuk adni a válasz alapján, hogy melyik kérdésre érkezett. Ha ez a pontosság "elég nagy" és a megfelelő kérdéshez tartozik, akkor elfogadunk, egyébként visszaadjuk a tanító halmaz elemeit, mely a helyes válaszlehetőségeket tartalmazza.

Mint minden mesterséges intelligencián alapuló szoftverben, itt is fenn áll a hibalehetőség. A tanár felülbírálhatja adott esetben a gép által ítélt eredményt, és ha diák kárára tévedtünk, válasza hozzáadható a tanító halmazhoz, mely által pontosíthatjuk eredményünket.

## Luis AI (Language understanding)

Példa alkalmazásunk a Microsoft Language Understanding szolgáltatását veszi igénybe. Arra használjuk, hogy "szándékokat" adjunk meg, mely maga a kérdés, és a hozzá tartozó "cselekvések" a válasz lehetséges értékei (tanító halmaz). A szoftver futtatása során a kérdésekre adott válaszok feleltethetők meg a cselekvésnek. Ha cselekvés alapján felismerjük szándékot, akkor a kérdésre helyes válasz érkezett.

Luis használata elég egyszerűnek bizonyult, mivel elvégzi helyettünk a betanítást és utána kitelepíti magát, ezért könnyű a fejlesztésre koncentrálni.

Luis-nak köszönhetően a számítások jelentős része a felhőben történik, melyet a web-es alkalmazásunk szervere ér el. A diákok és tanárok eszközein futó program csak a saját webszerverünkkel kommunikál, így az adatforgalmat az ő részükröl minimalizáljuk. Egy felelet illetve kérdés-válasz párok megadása során tulajdonképpen csak bájtokat fogyasztunk el, mely rendkívül előnyös és energiatakarékos egy képfeltöltős/videókonferenciás órához képest.

## Példa

Tegyünk fel egy egyszerű kérdést: "Hogy hívják a bűvös sárkányt az ismert dalban?"
A helyes válasz: Paff

Viszont nem várható el, hogy pontosan így adja vissza tanuló a választ, főleg ha mikrofonban beszél és azt elemezzük. A válaszában előfordulhatnak töltelék szavak/kifejezések, melyet egy ilyen MI-án alapuló szoftver képes lehet értelmezni.

Ezek alapján elfogadott válasz lehet: "Paff a bűvös sárkány", "Szerintem Paff", "A helyes válasz Paff" és így tovább.

A tanár felülbírálásának következménye lehet pozitív értelemben, hogy ha valaki helyesírási hibát vét, akkor azzal bővül tanító halmaz, így késöbbiekben elfogadott lehet: "Paf a sárkány" válasz is.

## A program működése

Jelen implementáció, konzolon mutatja be, milyen egyszerűen lehet kérdést és választ hozzáadni rendszerhez, valamint hogyan működik egy kikérdezés. Implemetáltunk egy példát is, melyet lefuttatva egy rövid felelési scenario-ban mutatjuk be a kérdésekre adott válaszlehetőségeket és visszajelzést.
