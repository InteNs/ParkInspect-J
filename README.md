# ParkInspect

# Gitflow

[uitleg](https://datasift.github.io/gitflow/IntroducingGitFlow.html)

### issues

iedere product use case krijgt een milestone met een deadline

er worden issues (naar wens) aangemaakt voor alle (eenpersoons) taken die nodig zijn voor die milestone

iemand wordt aan de issue geassigned, er wordt een geplanned aantal uren aan gehangen (dmv labels)

en de issue wordt aan die milestone gelinked.

### pull requests en commits

de branch-naam is (zonder hoofdletters) `feature/de-naam-van-de-milestone`

er wordt **een** branch en pull-request per milestone gemaakt

er wordt **per taak** een commit gemaakt door de persoon die die taak heeft uitgevoerd

de commit message bevat de tekst `closes #n / omschrijving` waar n het nummer van de issue is (niet `#` vergeten)

zodra de pull-request gemerged wordt, worden de issues automatisch geclosed

### bug fixes in de branch

natuurlijk pas de commit maken als je echt denkt klaar te zijn met die issue.

er mogen bugfix commits bij de pull request toegevoegd worden, de commit message wordt dan `bug-fix/dit was het probleem`


